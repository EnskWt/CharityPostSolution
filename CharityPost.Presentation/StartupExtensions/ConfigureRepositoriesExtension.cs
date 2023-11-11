using CharityPost.Core.Contracts.RepositoryContracts;
using CharityPost.Infrastructure.Repositories;

namespace CharityPost.Presentation.StartupExtensions
{
    public static class ConfigureRepositoriesExtension
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPublicationsRepository, PublicationsRepository>();

            return services;
        }
    }
}
