using CSharpFunctionalExtensions;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;

namespace OrganizationService.Application.Locations
{
    public interface ILocationsRepository
    {
        Task<Result<Guid, ErrorList>> Add(Location location, CancellationToken cancellationToken = default);
    }
}
