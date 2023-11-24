using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using CharityPost.Core.Helpers;

namespace CharityPost.Core.DataTransferObjects.PublicationObjects
{
    public class PublicationResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public PublicationCategories PublicationCategory { get; set; }
        public DateTime PublishedDate { get; set; }

        public int CurrentMoney { get; set; }
        public int TargetMoney { get; set; }
        public double Progress
        {
            get
            {
                double progress = CurrentMoney / TargetMoney * 100;

                if (progress > 100) return 100;
                if (progress < 0) return 0;

                return progress;
            }
        }

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
                PublicationCategory = publication.PublicationCategory,
                PublishedDate = publication.PublishedDate,
                CurrentMoney = publication.CurrentMoney,
                TargetMoney = publication.TargetMoney,
                ImagesUrls = ImagesConverterHelper.ConvertImagesByteArraysToUrls(publication.Images),
                AuthorId = publication.AuthorId,
                Author = publication.Author
            };
        }
    }
}
