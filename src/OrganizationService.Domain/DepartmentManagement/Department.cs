using OrganizationService.Domain.DepartmentLocationManagement;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;
using OrganizationService.Domain.DepartmentPositionManagement;
using Path = OrganizationService.Domain.DepartmentManagement.ValueObjects.Path;


namespace OrganizationService.Domain.DepartmentManagement
{
    public sealed class Department
    {
        private readonly List<DepartmentLocation> _departmentLocations = [];
        private readonly List<DepartmentPosition> _departmentPositions = [];

        // ef core
        private Department() { }

        private Department(
            Guid id,
            Name name,
            Identifier identifier,
            Guid? parentId,
            Path path,
            short depth,
            DateTime createdTime,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Identifier = identifier;
            ParentId = parentId;
            Path = path;
            Depth = depth;
            IsActive = true;
            CreatedAt = createdTime;
            UpdatedAt = updatedAt;
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; } = default!;
        public Identifier Identifier { get; private set; } = default!;
        public Guid? ParentId { get; private set; }
        public Path Path { get; private set; } = default!;
        public short Depth { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
        public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
    }
}
