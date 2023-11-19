using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using CharityPost.Core.Helpers;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CharityPost.Core.DataTransferObjects.PublicationObjects
{
    public class PublicationUpdateRequest : IPublicationRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public PublicationCategories PublicationCategory { get; set; }

        [Required]
        public List<IFormFile> Images { get; set; } = null!;

        public Publication ToPublication()
        {
            return new Publication
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Images = ImagesConverterHelper.ConvertImagesToByteArrays(Images)
            };
        }
    }
}
