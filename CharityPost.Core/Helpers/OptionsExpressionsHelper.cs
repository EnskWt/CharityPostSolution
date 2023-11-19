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
    public class OptionsExpressionsHelper : IOptionsExpressionsHelper
    {
        private readonly Dictionary<SortOptions, string> _sorts;

        private readonly Dictionary<FilterOptions, Func<string, Expression<Func<Publication, bool>>>> _filters;

        public OptionsExpressionsHelper()
        {
            _sorts = new Dictionary<SortOptions, string>
            {
                { SortOptions.Date, "PublishedDate" }
            };

            _filters = new Dictionary<FilterOptions, Func<string, Expression<Func<Publication, bool>>>>
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
                }
            };
        }

        public string GetSortExpression(SortOptions sortOption, SortOrderOptions sortOrderOption)
        {
            string expression = $"{_sorts[sortOption].Normalize()} {sortOrderOption}";
            return expression;
        }

        public Expression<Func<Publication, bool>> GetFilterExpression(Dictionary<FilterOptions, string> filters)
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
