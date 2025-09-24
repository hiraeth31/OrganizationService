using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.PositionManagement;
using OrganizationService.Domain.PositionManagement.ValueObjects;

namespace OrganizationService.Infrastructure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasConversion(
                value => value.Value,
                value => new PositionId(value));

            builder.ComplexProperty(d => d.Name, nb =>
            {
                nb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_POSITION_NAME_LENGTH)
                .IsRequired()
                .HasColumnName("name");
            });

            builder.ComplexProperty(d => d.Description, nb =>
            {
                nb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_POSITION_DESCRIPTION_LENGTH)
                .IsRequired()
                .HasColumnName("description");
            });

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasColumnName("is_active");

            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            builder.Property(d => d.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}
