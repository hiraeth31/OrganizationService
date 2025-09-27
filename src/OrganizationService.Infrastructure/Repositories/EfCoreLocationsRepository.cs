using Microsoft.Extensions.Configuration;
using OrganizationService.Application.Locations;
using OrganizationService.Domain.LocationManagement;

namespace OrganizationService.Infrastructure.Repositories
{
    public class EfCoreLocationsRepository : ILocationsRepository
    {
        private readonly OrganizationServiceDbContext _dbContext;

        public EfCoreLocationsRepository(OrganizationServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(Location location, CancellationToken cancellationToken)
        {
            await _dbContext.Locations.AddAsync(location, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return location.Id.Value;
        }
    }
}
