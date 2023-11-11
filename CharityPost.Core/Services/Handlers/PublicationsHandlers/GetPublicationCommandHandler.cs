using CharityPost.Core.Contracts.RepositoryContracts;
using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Handlers.PublicationsHandlers
{
    public class GetPublicationCommandHandler : IRequestHandler<GetPublicationCommand, PublicationResponse?>
    {
        private readonly IPublicationsRepository _publicationRepository;

        public GetPublicationCommandHandler(IPublicationsRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<PublicationResponse?> Handle(GetPublicationCommand request, CancellationToken cancellationToken)
        {
            if (request.PublicationId == null || !request.PublicationId.HasValue)
            {
                throw new ArgumentNullException();
            }

            var publication = await _publicationRepository.GetPublicationById(request.PublicationId.Value);
            return publication?.ToPublicationResponse();
        }
    }
}
