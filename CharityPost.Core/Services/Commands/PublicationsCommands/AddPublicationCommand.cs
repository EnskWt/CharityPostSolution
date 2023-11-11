using CharityPost.Core.DataTransferObjects.PublicationObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Commands.PublicationsCommands
{
    public class AddPublicationCommand : IRequest<Guid?>
    {
        public PublicationAddRequest? PublicationAddRequest { get; set; }

        public AddPublicationCommand(PublicationAddRequest? publicationAddRequest)
        {
            PublicationAddRequest = publicationAddRequest;
        }
    }
}
