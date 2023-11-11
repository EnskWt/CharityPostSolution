using CharityPost.Core.Domain.Entities.PublicationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.DataTransferObjects.PublicationObjectsContracts
{
    public interface IPublicationRequest
    {
        string Title { get; set; }
        string Description { get; set; }
        Publication ToPublication();
    }
}
