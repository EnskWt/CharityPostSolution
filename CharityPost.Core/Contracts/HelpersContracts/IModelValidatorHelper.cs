using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Contracts.HelpersContracts
{
    public interface IModelValidatorHelper<T> where T : class
    {
        Task ModelValidation(T model);
    }
}
