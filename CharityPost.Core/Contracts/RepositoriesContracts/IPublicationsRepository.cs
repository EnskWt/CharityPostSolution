using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.RepositoryContracts
{
    public interface IPublicationsRepository 
    {
        Task<List<Publication>> GetAllPublications(string sort, Expression<Func<Publication, bool>> filter, int pageNumber, int pageSize);
        Task<Publication?> GetPublicationById(Guid publicationId);

        Task<Guid> AddPublication(Publication publication);

        Task<Guid> UpdatePublication(Publication publication);

        Task<bool> DeletePublication(Guid publicationId);
    }
}
