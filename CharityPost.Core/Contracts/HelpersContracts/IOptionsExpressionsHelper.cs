﻿using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.HelpersContracts
{
    public interface IOptionsExpressionsHelper
    {
        string GetSortExpression(SortOptions sortOption, SortOrderOptions sortOrderOption);
        Expression<Func<Publication, bool>> GetFilterExpression(List<FilterOptions> filterOptions, string filterValue);
    }
}
