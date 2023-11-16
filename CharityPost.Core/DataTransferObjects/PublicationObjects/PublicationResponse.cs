using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Helpers;

namespace CharityPost.Core.DataTransferObjects.PublicationObjects
{
    public class PublicationResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime PublishedDate { get; set; }

        public List<string> ImagesUrls { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; } = null!;
    }

    public static class PublicationResponseExtensions
    {
        public static PublicationResponse ToPublicationResponse(this Publication publication)
        {
            return new PublicationResponse
            {
                Id = publication.Id,
                Title = publication.Title,
                Description = publication.Description,
                PublishedDate = publication.PublishedDate,
                ImagesUrls = ImagesConverterHelper.ConvertImagesByteArraysToUrls(publication.Images)
            };
        }
    }
}
