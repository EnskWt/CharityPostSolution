using CharityPost.Core.Domain.Entities.PublicationEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.DataTransferObjects.PublicationObjectsContracts
{
    public interface IPublicationRequest
    {
        string Title { get; set; }
        string Description { get; set; }
        List<IFormFile> Images { get; set; }
        Publication ToPublication();
    }
}
