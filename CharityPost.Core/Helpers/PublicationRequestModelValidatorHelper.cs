using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.DataTransferObjects.PublicationObjectsContracts;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public class PublicationRequestModelValidatorHelper : IModelValidatorHelper<IPublicationRequest>
    {
        public Task ModelValidation(IPublicationRequest model)
        {
            ValidationContext context = new ValidationContext(model);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (!isValid)
            {
                throw new ArgumentException(results.FirstOrDefault()?.ErrorMessage);
            }

            return Task.CompletedTask;
        }
    }
}
