using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using CharityPost.Core.Helpers;
using CharityPost.Core.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CharityPost.Core.DataTransferObjects.PublicationObjects
{
    public class PublicationUpdateRequest : IPublicationRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required field")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Title length must be in be beetween 10 and 100 characters")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Description is required field")]
        [StringLength(2000, MinimumLength = 100, ErrorMessage = "Description length must be in be beetween 100 and 2000 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Publication category must be mentioned")]
        public PublicationCategories PublicationCategory { get; set; }

        [Required(ErrorMessage = "Target money is required field")]
        [Range(100, 50000, ErrorMessage = "The amount of money requested must be between $100 and $50,000")]
        public double TargetMoney { get; set; }

        [Required(ErrorMessage = "You have to upload at least one image")]
        [DataType(DataType.Upload)]
        [FilesExtensions(Extensions = new string[] { "png", "jpg", "jpeg", "gif" })]
        public List<IFormFile> Images { get; set; } = null!;

        public Publication ToPublication()
        {
            return new Publication
            {
                Id = Id,
                Title = Title,
                Description = Description,
                TargetMoney = TargetMoney,
                PublicationCategory = PublicationCategory,
                Images = ImagesConverterHelper.ConvertImagesToByteArrays(Images)
            };
        }
    }

    public static class PublicationUpdateRequestExtensions
    {
        public static PublicationUpdateRequest ToPublicationUpdateRequest(this PublicationResponse publicationResponse)
        {
            return new PublicationUpdateRequest
            {
                Id = publicationResponse.Id,
                Title = publicationResponse.Title,
                Description = publicationResponse.Description,
                TargetMoney = publicationResponse.TargetMoney,
                PublicationCategory = publicationResponse.PublicationCategory
            };
        }
    }
}
