using OrganizationService.Application.Locations.AddLocation;
using Microsoft.Extensions.DependencyInjection;

namespace OrganizationService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<AddLocationHandler>();

            return services;
        }
    }
}
