using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_data.Configurations;

namespace registrationapp_data
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}