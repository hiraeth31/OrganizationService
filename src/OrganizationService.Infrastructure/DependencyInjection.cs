using Microsoft.Extensions.DependencyInjection;

namespace OrganizationService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            return services;
        }
    }
}
