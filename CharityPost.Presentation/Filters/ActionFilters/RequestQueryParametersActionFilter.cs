using CharityPost.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CharityPost.Presentation.Filters.ActionFilters
{
    public class RequestQueryParametersActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // before logic
            // here can be implemented logic to validate query parameters, for example pageSize can't be more than 100
            

            await next();

            // after logic

            // here can be implemented logic to save query parameters to ViewBag

            Controller controller = (Controller)context.Controller;

            var queryParameters = context.HttpContext.Request.Query;

            if (queryParameters != null && queryParameters.Count > 0)
            {
                foreach (var queryParameter in queryParameters)
                {
                    controller.ViewData[QueryParametersKeysNormalizerHelper.Normalize(queryParameter.Key)] = queryParameter.Value;
                }
            }
        }
    }
}
