using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using registrationapp_core.Models;

namespace registrationapp_data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Login)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
