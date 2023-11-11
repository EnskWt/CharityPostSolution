using CharityPost.Core.Contracts.HelpersContracts;
using CharityPost.Core.Helpers;

namespace CharityPost.Presentation.StartupExtensions
{
    public static class ConfigureHelpersExtension
    {
        public static IServiceCollection ConfigureHelpers(this IServiceCollection services)
        {
            services.AddScoped<IOptionsExpressionsHelper, OptionsExpressionsHelper>();

            return services;
        }
    }
}
