using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.HelpersContracts
{
    public interface IPublicationsContextValidatorHelper
    {
        Task<bool> IsPublicationOwnedByAuthor(Guid publicationId, Guid authorId);
    }
}
