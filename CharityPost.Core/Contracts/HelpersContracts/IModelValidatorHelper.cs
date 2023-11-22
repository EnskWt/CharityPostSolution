using CharityPost.Core.Domain.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.HelpersContracts
{
    public interface IModelValidatorHelper<T> where T : IValidatable
    {
        Task ModelValidation(T model);
    }
}
