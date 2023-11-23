using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public class PublicationsContextValidatorHelper : IPublicationsContextValidatorHelper
    {
        private readonly IMediator _mediator;

        public PublicationsContextValidatorHelper(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> IsPublicationOwnedByAuthor(Guid publicationId, Guid authorId)
        {
            var command = new GetPublicationCommand(publicationId);

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return false;
            }

            return result.AuthorId == authorId;
        }
    }
}
