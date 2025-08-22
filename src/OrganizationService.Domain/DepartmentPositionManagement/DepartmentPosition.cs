namespace OrganizationService.Domain.DepartmentPositionManagement
{
    public sealed class DepartmentPosition
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid PositionId { get; set; }
    }
}
