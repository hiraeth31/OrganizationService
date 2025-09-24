using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.DepartmentManagement;
using OrganizationService.Domain.DepartmentManagement.ValueObjects;

namespace OrganizationService.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");

            builder.HasKey(x => x.Id);

            builder.Property(d => d.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasConversion(
                value => value.Value,
                value => new DepartmentId(value));

            builder.ComplexProperty(d => d.Name, nb =>
            {
                nb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_DEPARTMENT_NAME_LENGTH)
                .IsRequired()
                .HasColumnName("name");
            });

            builder.ComplexProperty(d => d.Identifier, ib =>
            {
                ib.Property(id => id.Value)
                .HasMaxLength(Constants.MAX_DEPARTMENT_IDENTIFIER_LENGTH)
                .IsRequired()
                .HasColumnName("identifier");
            });

            builder.Property(d => d.ParentId)
                .IsRequired(false)
                .HasColumnName("parent_id");

            builder.ComplexProperty(d => d.Path, pb =>
            {
                pb.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("path");
            });

            builder.Property(d => d.Depth)
                .IsRequired()
                .HasColumnName("depth");

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasColumnName("is_active");

            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(d => d.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");

            builder.HasMany(d => d.ChildrenDepartments)
                .WithOne(cd => cd.Parent)
                .IsRequired(false)
                .HasForeignKey(d => d.ParentId);
        }
    }
}
