using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationService.Domain.DepartmentLocationManagement;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;
using OrganizationService.Domain.DepartmentPositionManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;

namespace OrganizationService.Infrastructure.Configurations
{
    public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
    {
        public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
        {
            builder.ToTable("department_locations");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasConversion(
                value => value.Value,
                value => new DepartmentLocationId(value));

            builder.Property(d => d.LocationId)
                .IsRequired()
                .HasColumnName("locaion_id")
                .HasConversion(
                value => value.Value,
                value => new LocationId(value));

            builder.Property(d => d.DepartmentId)
                .IsRequired()
                .HasColumnName("department_id")
                .HasConversion(
                value => value.Value,
                value => new DepartmentId(value));

            builder.HasOne(d => d.Location)
                .WithMany(d => d.DepartmentLocations)
                .HasForeignKey(d => d.LocationId);

            builder.HasOne(d => d.Department)
                .WithMany(d => d.DepartmentLocations)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
