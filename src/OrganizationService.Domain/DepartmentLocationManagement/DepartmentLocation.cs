using OrganizationService.Domain.DepartmentManagement;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;
using OrganizationService.Domain.LocationManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;

namespace OrganizationService.Domain.DepartmentLocationManagement
{
    public sealed class DepartmentLocation
    {
        private DepartmentLocation() { }


        public DepartmentLocationId Id { get; private set; }
        public DepartmentId DepartmentId { get; private set; }
        public LocationId LocationId { get; private set; }

        public Department Department { get; private set; }
        public Location Location { get; private set; }
    }
}
