using OrganizationService.Domain.DepartmentPositionManagement;
using OrganizationService.Domain.PositionManagement.ValueObjects;

namespace OrganizationService.Domain.PositionManagement
{
    public sealed class Position
    {
        private readonly List<DepartmentPosition> _departmentPositions = [];

        // ef core
        private Position() { }

        private Position(
            PositionId id,
            Name name,
            Description description,
            DateTime createdTime,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = true;
            CreatedAt = createdTime;
            UpdatedAt = updatedAt;
        }

        public PositionId Id { get; private set; }
        public Name Name { get; private set; } = default!;
        public Description Description { get; private set; } = default!;
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
    }
}
