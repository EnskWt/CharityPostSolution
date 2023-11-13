using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Enums;
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
        public List<FilterOptions> FilterOptions { get; set; } = new List<FilterOptions>();
        public string FilterValue { get; set; } = null!;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetPublicationsCommand() { }

        public GetPublicationsCommand(SortOptions sortOption, SortOrderOptions sortOrderOption, List<FilterOptions>? filterOptions, string? filterValue, int pageNumber, int pageSize)
        {
            SortOption = sortOption;
            SortOrderOptions = sortOrderOption;
            FilterOptions = filterOptions ?? new List<FilterOptions>();
            FilterValue = filterValue ?? string.Empty;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
