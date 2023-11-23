using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Domain.RepositoriesContracts;
using CharityPost.Core.Helpers;
using CharityPost.Core.Services.Commands.PublicationsCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Handlers.PublicationsHandlers
{
    public class GetPublicationsCommandHandler : IRequestHandler<GetPublicationsCommand, List<PublicationResponse>?>
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public GetPublicationsCommandHandler(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<List<PublicationResponse>?> Handle(GetPublicationsCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }

            string sortExpression = OptionsExpressionsHelper.GetSortExpression(request.SortOption, request.SortOrderOptions);
            Expression<Func<Publication, bool>> filterExpression = OptionsExpressionsHelper.GetFilterExpression(request.Filters);
            
            var publications = await _publicationsRepository.GetAllPublications(sortExpression, filterExpression, request.PageNumber, request.PageSize);
            return publications.Select(p => p.ToPublicationResponse()).ToList();
        }
    }
}
