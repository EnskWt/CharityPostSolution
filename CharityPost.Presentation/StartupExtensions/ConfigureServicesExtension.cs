using CharityPost.Core.Services.Handlers.PublicationsHandlers;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace CharityPost.Presentation.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetPublicationCommandHandler>()); // ?

            return services;
        }
    }
}
