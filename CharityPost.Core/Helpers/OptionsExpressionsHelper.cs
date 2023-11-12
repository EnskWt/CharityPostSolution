using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums;
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
                { FilterOptions.None , (value) => (publication) => true },
                //{ FilterOptions.Author, (value) => (publication) => publication.Author == value}
                { FilterOptions.Category, (value) => (publication) => publication.PublicationCategory == Enum.Parse<PublicationCategories>(value) }      
            };
        }

        public string GetSortExpression(SortOptions sortOption, SortOrderOptions sortOrderOption)
        {
            string expression = $"{_sorts[sortOption].Normalize()} {sortOrderOption}";
            return expression;
        }

        public Expression<Func<Publication, bool>> GetFilterExpression(List<FilterOptions> filterOptions, string filterValue)
        {
            var predicateExpression = PredicateBuilder.New<Publication>();

            foreach (var filterOption in filterOptions)
            {
                predicateExpression = predicateExpression.And(_filters[filterOption](filterValue));
            }

            return predicateExpression;
        }
    }
}
