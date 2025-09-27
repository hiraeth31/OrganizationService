using OrganizationService.Domain.LocationManagement;

namespace OrganizationService.Application.Locations
{
    public interface ILocationsRepository
    {
        Task<Guid> Add(Location location, CancellationToken cancellationToken = default);
    }
}
