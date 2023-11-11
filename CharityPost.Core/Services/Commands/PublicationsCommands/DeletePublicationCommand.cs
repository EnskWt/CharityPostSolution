using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Commands.PublicationsCommands
{
    public class DeletePublicationCommand : IRequest<bool?>
    {
        public Guid? PublicationId { get; set; }

        public DeletePublicationCommand(Guid publicationId)
        {
            PublicationId = publicationId;
        }
    }
}
