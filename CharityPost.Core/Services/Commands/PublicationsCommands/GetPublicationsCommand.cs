using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Commands.PublicationsCommands
{
    public class GetPublicationsCommand : IRequest<List<PublicationResponse>?>
    {
        public SortOptions SortOption { get; set; } = SortOptions.Date;
        public SortOrderOptions SortOrderOptions { get; set; } = SortOrderOptions.ASC;
        public Dictionary<FilterOptions, string> Filters { get; set; } = new Dictionary<FilterOptions, string>();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetPublicationsCommand() { }

        public GetPublicationsCommand(SortOptions sortOption, SortOrderOptions sortOrderOption, Dictionary<FilterOptions, string> filters, int pageNumber, int pageSize)
        {
            SortOption = sortOption;
            SortOrderOptions = sortOrderOption;
            Filters = filters;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
