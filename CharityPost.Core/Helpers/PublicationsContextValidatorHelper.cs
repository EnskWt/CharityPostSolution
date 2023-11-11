using CharityPost.Core.Contracts.HelpersContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public class PublicationsContextValidatorHelper : IPublicationsContextValidatorHelper
    {
        public Task<bool> IsPublicationExists(Guid publicationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPublicationOwnedAuthor(Guid publicationId, Guid authorId)
        {
            throw new NotImplementedException();
        }
    }
}
