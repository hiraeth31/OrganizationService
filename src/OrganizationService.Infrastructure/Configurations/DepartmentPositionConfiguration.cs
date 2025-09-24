using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;
using OrganizationService.Domain.DepartmentPositionManagement;
using OrganizationService.Domain.PositionManagement.ValueObjects;

namespace OrganizationService.Infrastructure.Configurations
{
    public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
    {
        public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
        {
            builder.ToTable("department_positions");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasConversion(
                value => value.Value,
                value => new DepartmentPositionId(value));

            builder.Property(d => d.PositionId)
                .IsRequired()
                .HasColumnName("position_id")
                .HasConversion(
                value => value.Value,
                value => new PositionId(value));

            builder.Property(d => d.DepartmentId)
                .IsRequired()
                .HasColumnName("department_id")
                .HasConversion(
                value => value.Value,
                value => new DepartmentId(value));

            builder.HasOne(d => d.Position)
                .WithMany(d => d.DepartmentPositions)
                .HasForeignKey(d => d.PositionId);

            builder.HasOne(d => d.Department)
                .WithMany(d => d.DepartmentPositions)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
