using CharityPost.Core.DataTransferObjects.PublicationObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Commands.PublicationsCommands
{
    public class GetPublicationCommand : IRequest<PublicationResponse?>
    {
        public Guid? PublicationId { get; set; }

        public GetPublicationCommand(Guid publicationId)
        {
            PublicationId = publicationId;
        }
    }
}
