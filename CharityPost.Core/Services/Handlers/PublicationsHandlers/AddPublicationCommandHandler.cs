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
    public class AddPublicationCommandHandler : IRequestHandler<AddPublicationCommand, Guid?>
    {
        private readonly IPublicationsRepository _publicationRepository;

        public AddPublicationCommandHandler(IPublicationsRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<Guid?> Handle(AddPublicationCommand request, CancellationToken cancellationToken)
        {
            if (request.PublicationAddRequest == null)
            {
                throw new ArgumentNullException();
            }

            var addedPublicationId = await _publicationRepository.AddPublication(request.PublicationAddRequest.ToPublication());
            return addedPublicationId;
        }
    }
}
