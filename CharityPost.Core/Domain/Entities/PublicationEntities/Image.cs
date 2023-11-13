using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Domain.Entities.PublicationEntities
{
    public class Image
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; } = null!;

        public Guid PublicationId { get; set; }
        public virtual Publication Publication { get; set; } = null!;
    }
}
