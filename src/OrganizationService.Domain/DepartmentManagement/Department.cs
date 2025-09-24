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
        private readonly List<Department> _childrenDepartments = [];

        // ef core
        private Department() { }

        private Department(
            DepartmentId id,
            Name name,
            Identifier identifier,
            Department? parent,
            Path path,
            short depth,
            DateTime createdTime,
            DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Identifier = identifier;
            Parent = parent;
            Path = path;
            Depth = depth;
            IsActive = true;
            CreatedAt = createdTime;
            UpdatedAt = updatedAt;
        }

        public DepartmentId Id { get; private set; }
        public Name Name { get; private set; } = default!;
        public Identifier Identifier { get; private set; } = default!;
        public DepartmentId? ParentId { get; private set; }
        public Path Path { get; private set; } = default!;
        public short Depth { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Department? Parent { get; private set; }
        public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;
        public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
        public IReadOnlyList<Department> ChildrenDepartments => _childrenDepartments;
    }
}
