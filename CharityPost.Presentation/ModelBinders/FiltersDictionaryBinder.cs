using CharityPost.Core.Enums.PublicationRelatedEnums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CharityPost.Presentation.ModelBinders
{
    public class FiltersDictionaryBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var filters = new Dictionary<FilterOptions, string>();

            foreach (var key in bindingContext.HttpContext.Request.Query.Keys)
            {
                if (key.StartsWith(bindingContext.ModelName + "[") && key.EndsWith("]") && Enum.TryParse(key.Substring(bindingContext.ModelName.Length + 1, key.Length - bindingContext.ModelName.Length - 2), out FilterOptions filterOption))
                {
                    filters[filterOption] = bindingContext.HttpContext.Request.Query[key]!;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(filters);

            return Task.CompletedTask;
        }
    }
}
