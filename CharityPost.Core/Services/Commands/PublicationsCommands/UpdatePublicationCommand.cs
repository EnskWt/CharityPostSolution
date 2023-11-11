using CharityPost.Core.DataTransferObjects.PublicationObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Services.Commands.PublicationsCommands
{
    public class UpdatePublicationCommand : IRequest<Guid?>
    {
        public PublicationUpdateRequest? PublicationUpdateRequest { get; set; }

        public UpdatePublicationCommand(PublicationUpdateRequest? publicationUpdateRequest)
        {
            PublicationUpdateRequest = publicationUpdateRequest;
        }
    }
}
