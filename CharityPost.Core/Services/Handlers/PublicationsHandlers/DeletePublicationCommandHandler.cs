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
    public class DeletePublicationCommandHandler : IRequestHandler<DeletePublicationCommand, bool?>
    {
        private readonly IPublicationsRepository _publicationRepository;

        public DeletePublicationCommandHandler(IPublicationsRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        public async Task<bool?> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            if (request.PublicationId == null || !request.PublicationId.HasValue)
            {
                throw new ArgumentNullException();
            }

            var isDeleted = await _publicationRepository.DeletePublication(request.PublicationId.Value);
            return isDeleted;
        }
    }
}
