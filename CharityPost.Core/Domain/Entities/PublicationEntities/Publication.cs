using CharityPost.Core.Enums;
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
    }
}
