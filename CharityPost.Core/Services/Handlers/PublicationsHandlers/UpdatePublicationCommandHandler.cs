using CharityPost.Core.Domain.RepositoriesContracts;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Handlers.PublicationsHandlers
{
    public class UpdatePublicationCommandHandler : IRequestHandler<UpdatePublicationCommand, Guid?>
    {
        private readonly IPublicationsRepository _publicationRepository;

        public UpdatePublicationCommandHandler(IPublicationsRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Guid?> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            if (request.PublicationUpdateRequest == null)
            {
                throw new ArgumentNullException();
            }

            var updatedPublicationId = await _publicationRepository.UpdatePublication(request.PublicationUpdateRequest.ToPublication());
            return updatedPublicationId;
        }
    }
}
