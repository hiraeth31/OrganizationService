using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using OrganizationService.Application.Locations;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;

namespace OrganizationService.Infrastructure.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly OrganizationServiceDbContext _dbContext;

        public LocationsRepository(OrganizationServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Guid, ErrorList>> Add(Location location, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.Locations.AddAsync(location, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return location.Id.Value;
            }
            catch (Exception)
            {
                return Errors.General.ValueIsInvalid().ToErrorList();
            }
        }
    }
}
