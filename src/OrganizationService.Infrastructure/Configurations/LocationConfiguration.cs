using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizationService.Domain.Common;
using OrganizationService.Domain.LocationManagement;
using OrganizationService.Domain.LocationManagement.ValueObjects;
using System.Text.Json;

namespace OrganizationService.Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasConversion(
                value => value.Value,
                value => new LocationId(value));

            builder.ComplexProperty(l => l.Name, nb =>
            {
                nb.Property(n => n.Value)
                .HasMaxLength(Constants.MAX_LOCATION_NAME_LENGTH)
                .IsRequired()
                .HasColumnName("name");
            });

            builder.ComplexProperty(l => l.Timezone, tb =>
            {
                tb.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("timezone");
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

            builder.OwnsMany(d => d.Addresses, ab =>
            {
                ab.ToJson();

                ab.Property(ad => ad.Country)
                .IsRequired()
                .HasColumnName("country");

                ab.Property(ad => ad.City)
                .IsRequired()
                .HasColumnName("city");

                ab.Property(ad => ad.Street)
                .IsRequired()
                .HasColumnName("street");

                ab.Property(ad => ad.House)
                .IsRequired()
                .HasColumnName("house");
            });
        }
    }
}
