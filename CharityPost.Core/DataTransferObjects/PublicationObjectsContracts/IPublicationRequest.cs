using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Domain.Markers;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.DataTransferObjects.PublicationObjectsContracts
{
    public interface IPublicationRequest : IValidatable
    {
        string Title { get; set; }
        string Description { get; set; }
        int TargetMoney { get; set; }
        PublicationCategories PublicationCategory { get; set; }
        List<IFormFile> Images { get; set; }
        Publication ToPublication();
    }
}
