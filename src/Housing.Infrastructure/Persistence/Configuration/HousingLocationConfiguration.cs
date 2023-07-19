using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Infrastructure.Persistence.Configuration;

public class HousingLocationConfiguration : IEntityTypeConfiguration<HousingLocationEntity>
{
    public void Configure(EntityTypeBuilder<HousingLocationEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(512)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(x => x.City)
            .HasMaxLength(512)
            .HasColumnName("city")
            .IsRequired();
        
        builder.Property(x => x.State)
            .HasMaxLength(256)
            .HasColumnName("state")
            .IsRequired();

        builder.Property(x => x.Photo)
            .HasMaxLength(512)
            .HasColumnName("photo")
            .IsRequired(false);
        
        builder.Property(x => x.AvailableUnits)
            .HasColumnName("available_units")
            .IsRequired();

        builder.Property(x => x.Wifi)
            .HasColumnName("wifi")
            .IsRequired();
        
        builder.Property(x => x.Laundry)
            .HasColumnName("laundry")
            .IsRequired();
    }
}