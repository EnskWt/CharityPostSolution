using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
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

        public Publication ToPublication()
        {
            return new Publication
            {
                Id = Id,
                Title = Title,
                Description = Description
            };
        }
    }
}
