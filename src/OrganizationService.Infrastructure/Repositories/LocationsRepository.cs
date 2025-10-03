using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrganizationService.Application.Locations;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;

namespace OrganizationService.Infrastructure.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly OrganizationServiceDbContext _dbContext;
        private readonly ILogger<LocationsRepository> _logger;

        public LocationsRepository(
            OrganizationServiceDbContext dbContext,
            ILogger<LocationsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Add(Location location, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.Locations.AddAsync(location, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return location.Id.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Add location exception");

                return Errors.General.ValueIsInvalid().ToErrorList();
            }
        }
    }
}
