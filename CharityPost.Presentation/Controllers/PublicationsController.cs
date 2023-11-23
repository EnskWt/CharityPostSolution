using CharityPost.Core.Enums.PublicationRelatedEnums;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using CharityPost.Presentation.Filters.ActionFilters;
using CharityPost.Presentation.ModelBinders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityPost.Presentation.Controllers
{
    [AllowAnonymous]
    public class PublicationsController : Controller
    {
        private readonly IMediator _mediator;

        public PublicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [TypeFilter(typeof(RequestQueryParametersActionFilter))]
        [Route("/")]
        [Route("/publications")]
        public async Task<IActionResult> Index(
            [FromQuery] SortOptions sortOption = SortOptions.Date,
            [FromQuery] SortOrderOptions sortOrderOption = SortOrderOptions.ASC,
            [FromQuery, ModelBinder(typeof(FiltersDictionaryBinder))] Dictionary<FilterOptions, string> filters = null!,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {
            var command = new GetPublicationsCommand(sortOption, sortOrderOption, filters, pageNumber, pageSize);
            var result = await _mediator.Send(command);

            return View(result);
        }

        [Route("/publications/{id}")]
        public async Task<IActionResult> PublicationDetails(Guid id)
        {
            var command = new GetPublicationCommand(id);
            var result = await _mediator.Send(command);

            return View(result);
        }
    }
}
