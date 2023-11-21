using CharityPost.Core.Enums.PublicationRelatedEnums;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CharityPost.Presentation.Filters.ActionFilters
{
    public class AuthorFilterOptionActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // before logic

            var filters = context.ActionArguments["filters"] as Dictionary<FilterOptions, string>;

            if (filters == null)
            {
                filters = new Dictionary<FilterOptions, string>();
            }

            string userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            if (filters.Any(f => f.Key == FilterOptions.Author))
            {
                if (filters[FilterOptions.Author] != userId)
                {
                    filters[FilterOptions.Author] = userId;
                }
            }
            else
            {
                filters.Add(FilterOptions.Author, userId);
            }

            context.ActionArguments["filters"] = filters;

            await next();

            // after logic
        }

    }
}
