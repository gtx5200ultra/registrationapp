using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using registrationapp_core.Models;

namespace registrationapp_data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
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

            builder.HasData(new List<Country> { 
                    new()
                    {
                        Id = 1,
                        Name = "Country 1"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Country 2"
                    }
                }
            );
        }
    }
}
