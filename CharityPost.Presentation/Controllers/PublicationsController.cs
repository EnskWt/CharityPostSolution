using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Enums;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CharityPost.Presentation.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IMediator _mediator;

        public PublicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/")]
        public async Task<IActionResult> Index([FromQuery] SortOptions sortOption = SortOptions.Date, [FromQuery] SortOrderOptions sortOrderOption = SortOrderOptions.ASC, [FromQuery] List<FilterOptions>? filterOptions = null, [FromQuery] string? filterValue = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var command = new GetPublicationsCommand(sortOption, sortOrderOption, filterOptions, filterValue, pageNumber, pageSize);
            var result = await _mediator.Send(command);

            var publications = new List<PublicationResponse>()
            {
                new PublicationResponse
                {
                    Id = Guid.NewGuid(),
                    Title = "Test1",
                    Description = "Test1",
                    PublishedDate = DateTime.UtcNow
                },
                new PublicationResponse
                {
                    Id = Guid.NewGuid(),
                    Title = "Test2",
                    Description = "Test2",
                    PublishedDate = DateTime.UtcNow
                },
                new PublicationResponse
                {
                    Id = Guid.NewGuid(),
                    Title = "Test3",
                    Description = "Test3",
                    PublishedDate = DateTime.UtcNow
                },
            };

            return View(publications);
        }

        [Route("/publications/{id}")]
        public async Task<IActionResult> PublicationDetails(Guid id)
        {
            var command = new GetPublicationCommand(id);
            var result = await _mediator.Send(command);

            var publication = new PublicationResponse
            {
                Id = Guid.NewGuid(),
                Title = "TestTitle",
                Description = "TestDescription",
                PublishedDate = DateTime.UtcNow,
                Author = new Core.Domain.Entities.IdentityEntities.ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "TestName",
                    LastName = "TestSurname",
                    Email = ""
                }
            };

            return View(publication);
        }
    }
}
