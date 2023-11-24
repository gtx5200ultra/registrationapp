﻿using Microsoft.EntityFrameworkCore;
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
            builder.Entity<Country>()
                .HasMany(e => e.Provinces)
                .WithOne(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<Country>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .HasPrincipalKey(e => e.Id);

            builder.Entity<Province>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Province)
                .HasForeignKey(e => e.ProvinceId)
                .HasPrincipalKey(e => e.Id);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new ProvinceConfiguration());
        }
    }
}