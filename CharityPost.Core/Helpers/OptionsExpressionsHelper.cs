using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public static class OptionsExpressionsHelper // todo: static class
    {
        private static readonly Dictionary<SortOptions, string> _sorts = new Dictionary<SortOptions, string>
        {
            { SortOptions.Date, "PublishedDate" }
            // add more sorts here
        };

        private static readonly Dictionary<FilterOptions, Func<string, Expression<Func<Publication, bool>>>> _filters = new Dictionary<FilterOptions, Func<string, Expression<Func<Publication, bool>>>>
        {
            { FilterOptions.Author, (value) =>
                {
                    Guid authorId;
                    var parseResult = Guid.TryParse(value, out authorId);
                    return (publication) => publication.AuthorId == authorId;
                }
            },
            { FilterOptions.Category, (value) =>
                {
                    PublicationCategories category;
                    var parseResult = Enum.TryParse(value, out category);
                    return (publication) => publication.PublicationCategory == category;
                }
            },
            { FilterOptions.Title, (value) =>
                {
                    return (publication) => publication.Title.Contains(value.ToLower());
                }
            }
            // add more filters here
        };

        public static string GetSortExpression(SortOptions sortOption, SortOrderOptions sortOrderOption)
        {
            string expression = $"{_sorts[sortOption].Normalize()} {sortOrderOption}";
            return expression;
        }

        public static Expression<Func<Publication, bool>> GetFilterExpression(Dictionary<FilterOptions, string> filters)
        {
            var predicateExpression = PredicateBuilder.New<Publication>(true);

            foreach (var filter in filters)
            {
                if (_filters.ContainsKey(filter.Key))
                {
                    predicateExpression = predicateExpression.And(_filters[filter.Key](filter.Value));
                }
            }

            return predicateExpression;
        }
    }
}
