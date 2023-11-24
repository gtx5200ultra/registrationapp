using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using registrationapp_core.Models;

namespace registrationapp_data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasData(new List<Province> {
                new()
                {
                    Id = 1,
                    Name = "Province 1.1",
                    CountryId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Province 1.2",
                    CountryId = 1
                },
                new()
                {
                    Id = 3,
                    Name = "Province 2.1",
                    CountryId = 2
                },
                new()
                {
                    Id = 4,
                    Name = "Province 2.2",
                    CountryId = 2
                },
                new()
                {
                    Id = 5,
                    Name = "Province 2.3",
                    CountryId = 2
                },
            });
        }
    }
}
