﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using registrationapp_data;

#nullable disable

namespace registrationapp_data.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("registrationapp_core.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Country 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Country 2"
                        });
                });

            modelBuilder.Entity("registrationapp_core.Models.CountryRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryRegions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Province 1.1"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Province 1.2"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Province 2.1"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Province 2.2"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Province 2.3"
                        });
                });

            modelBuilder.Entity("registrationapp_core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryRegionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryRegionId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("registrationapp_core.Models.CountryRegion", b =>
                {
                    b.HasOne("registrationapp_core.Models.Country", "Country")
                        .WithMany("CountryRegions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("registrationapp_core.Models.User", b =>
                {
                    b.HasOne("registrationapp_core.Models.CountryRegion", "CountryRegion")
                        .WithMany("Users")
                        .HasForeignKey("CountryRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CountryRegion");
                });

            modelBuilder.Entity("registrationapp_core.Models.Country", b =>
                {
                    b.Navigation("CountryRegions");
                });

            modelBuilder.Entity("registrationapp_core.Models.CountryRegion", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
