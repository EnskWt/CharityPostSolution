using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
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
        private readonly IModelValidatorHelper<IPublicationRequest> _modelValidatorHelper;
        private readonly IPublicationsRepository _publicationRepository;

        public UpdatePublicationCommandHandler(IModelValidatorHelper<IPublicationRequest> modelValidatorHelper, IPublicationsRepository publicationRepository)
        {
            _modelValidatorHelper = modelValidatorHelper;
            _publicationRepository = publicationRepository;
        }

        public async Task<Guid?> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            if (request.PublicationUpdateRequest == null)
            {
                throw new ArgumentNullException();
            }

            await _modelValidatorHelper.ModelValidation(request.PublicationUpdateRequest);

            var updatedPublicationId = await _publicationRepository.UpdatePublication(request.PublicationUpdateRequest.ToPublication());
            return updatedPublicationId;
        }
    }
}
