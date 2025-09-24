using OrganizationService.Domain.DepartmentLocationManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;

namespace OrganizationService.Domain.LocationManagement
{
    public sealed class Location
    {
        private readonly List<DepartmentLocation> _departmentLocations = [];

        // ef core
        private Location() { }

        private readonly List<Address> _addresses = [];

        private Location(
            LocationId id,
            Name name,
            Timezone timezone,
            IEnumerable<Address> addresses,
            DateTime createdTime,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Timezone = timezone;
            _addresses = [.. addresses];
            IsActive = true;
            CreatedAt = createdTime;
            UpdatedAt = updatedAt;
        }

        public LocationId Id { get; private set; }
        public Name Name { get; private set; } = default!;
        public Timezone Timezone { get; private set; } = default!;
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IReadOnlyList<Address> Addresses => _addresses;
        public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
    }
}
