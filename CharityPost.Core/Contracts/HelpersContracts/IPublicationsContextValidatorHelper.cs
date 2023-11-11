using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.HelpersContracts
{
    public interface IPublicationsContextValidatorHelper
    {
        Task<bool> IsPublicationOwnedAuthor(Guid publicationId, Guid authorId);
    }
}
