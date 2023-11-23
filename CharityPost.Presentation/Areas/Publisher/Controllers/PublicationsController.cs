using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using CharityPost.Presentation.Filters.ActionFilters;
using CharityPost.Presentation.ModelBinders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CharityPost.Presentation.Areas.Publisher.Controllers
{
    [Area("Publisher")]
    [Route("/my-publications")]
    [Authorize(Roles = "Publisher")]
    /*[AllowAnonymous]*/  /*for test purposes*/
    public class PublicationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IMediator _mediator;

        private readonly IPublicationsContextValidatorHelper _publicationsContextValidatorHelper;

        public PublicationsController(UserManager<ApplicationUser> userManager, IMediator mediator, IPublicationsContextValidatorHelper publicationsContextValidatorHelper)
        {
            _userManager = userManager;
            _mediator = mediator;
            _publicationsContextValidatorHelper = publicationsContextValidatorHelper;
        }

        // add action filter that add user id to filters (using filter context)
        // prevent inserting another publisher id to filters !!!!!!!!!
        [TypeFilter(typeof(AuthorFilterOptionActionFilter))]
        [TypeFilter(typeof(RequestQueryParametersActionFilter))]
        [Route("/my-publications")]
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

        [HttpGet]
        [Route("new-publication")]
        public async Task<IActionResult> CreatePublication()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ModelStateCheckActionFilter), Arguments = new object[] { typeof(PublicationsController), "publicationRequest" })]
        [Route("new-publication")]
        public async Task<IActionResult> CreatePublication(PublicationAddRequest publicationRequest)
        {
            var command = new AddPublicationCommand(publicationRequest);
            var result = await _mediator.Send(command);

            return RedirectToAction("PublicationDetails", new { id = result });
        }

        [HttpGet]
        [Route("edit-publication/{id}")]
        public async Task<IActionResult> EditPublication(Guid id)
        {
            var ownershipValidationResult = await ValidateUserPublicationOwnership(id);
            if (ownershipValidationResult != null)
            {
                return ownershipValidationResult;
            }

            var command = new GetPublicationCommand(id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return RedirectToAction("Index", "Publications");
            }

            return View(result.ToPublicationUpdateRequest());
        }

        [HttpPost]
        [TypeFilter(typeof(ModelStateCheckActionFilter), Arguments = new object[] { typeof(PublicationsController), "publicationRequest" })]
        [Route("edit-publication/{id}")]
        public async Task<IActionResult> EditPublication(PublicationUpdateRequest publicationRequest)
        {
            var ownershipValidationResult = await ValidateUserPublicationOwnership(publicationRequest.Id);
            if (ownershipValidationResult != null)
            {
                return ownershipValidationResult;
            }

            var command = new UpdatePublicationCommand(publicationRequest);
            var result = await _mediator.Send(command);

            return RedirectToAction("PublicationDetails", new { id = result });
        }

        [HttpGet]
        [Route("delete-publication/{id}")]
        public async Task<IActionResult> DeletePublication(Guid id)
        {
            var ownershipValidationResult = await ValidateUserPublicationOwnership(id);
            if (ownershipValidationResult != null)
            {
                return ownershipValidationResult;
            }

            var command = new DeletePublicationCommand(id);
            var result = await _mediator.Send(command);
            // TODO: notification if result true or false

            return RedirectToAction("Index");
        }

        private async Task<IActionResult?> ValidateUserPublicationOwnership(Guid publicationId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Publications");
            }

            var isPublicationOwnedByAuthor = await _publicationsContextValidatorHelper.IsPublicationOwnedByAuthor(publicationId, user.Id);
            if (!isPublicationOwnedByAuthor)
            {
                return RedirectToAction("Index", "Publications");
            }

            return null;
        }
    }
}
