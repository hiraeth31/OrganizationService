using Microsoft.Extensions.DependencyInjection;
using OrganizationService.Application.Locations;
using OrganizationService.Domain.Common;
using OrganizationService.Infrastructure.Common;
using OrganizationService.Infrastructure.Dapper;
using OrganizationService.Infrastructure.Repositories;

namespace OrganizationService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<OrganizationServiceDbContext>();

            services.AddSingleton<IDbConnectionFactory, DapperConnectionFactory>();

            services.AddScoped<ILocationsRepository, DapperLocationsRepository>();

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
