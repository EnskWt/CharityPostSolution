using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace CharityPost.Presentation.Filters.ActionFilters
{
    public class ModelStateCheckActionFilter : IAsyncActionFilter
    {
        private readonly Type _controllerType;
        private readonly string _argumentName;

        public ModelStateCheckActionFilter(Type controllerType, string argumentName)
        {
            _controllerType = controllerType;
            _argumentName = argumentName;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // before logic

            if (context.Controller.GetType() == _controllerType && context.Controller is Controller controller)
            {
                if (!context.ModelState.IsValid)
                {
                    var argumentObject = context.ActionArguments[_argumentName];

                    context.Result = controller.View(argumentObject);
                }
                else
                {
                    await next();
                }
            }
            else
            {
                await next();
            }

            // after logic
        }
    }
}
