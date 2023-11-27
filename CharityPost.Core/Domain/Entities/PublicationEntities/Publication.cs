using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Enums.PublicationRelatedEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Domain.Entities.PublicationEntities
{
    public class Publication
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public PublicationCategories PublicationCategory { get; set; }
        public DateTime PublishedDate { get; set; }

        public double CurrentMoney { get; set; } = 0;
        public double TargetMoney { get; set; }

        public virtual List<Image> Images { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; } = null!;
    }
}
