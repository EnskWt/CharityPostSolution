using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CharityPost.Core.DataTransferObjects.PublicationObjects
{
    public class PublicationAddRequest : IPublicationRequest
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public PublicationCategories PublicationCategory { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid AuthorId { get; set; }

        public Publication ToPublication()
        {
            return new Publication
            {
                Title = Title,
                Description = Description,
                PublicationCategory = PublicationCategory,
                PublishedDate = PublishedDate,
                AuthorId = AuthorId
            };
        }
    }
}
