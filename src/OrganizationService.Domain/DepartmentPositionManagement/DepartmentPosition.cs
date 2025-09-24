using OrganizationService.Domain.DepartmentManagement;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;
using OrganizationService.Domain.PositionManagement;
using OrganizationService.Domain.PositionManagement.ValueObjects;

namespace OrganizationService.Domain.DepartmentPositionManagement
{
    public sealed class DepartmentPosition
    {
        private DepartmentPosition() { }

        public DepartmentPositionId Id { get; private set; }
        public DepartmentId DepartmentId { get; private set; }
        public PositionId PositionId { get; private set; }

        public Department Department { get; private set; }
        public Position Position { get; private set; }
    }
}
