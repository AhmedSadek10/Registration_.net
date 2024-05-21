﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Persistance;

#nullable disable

namespace Registration.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240520113414_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Registration.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("Registration.Domain.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GovernateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GovernateId");

                    b.ToTable("Citys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Cairo",
                            GovernateId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Giza",
                            GovernateId = 2
                        },
                        new
                        {
                            Id = 6,
                            City = "6 October",
                            GovernateId = 2
                        },
                        new
                        {
                            Id = 3,
                            City = "Alexandria",
                            GovernateId = 3
                        },
                        new
                        {
                            Id = 4,
                            City = "Mansoura",
                            GovernateId = 5
                        },
                        new
                        {
                            Id = 5,
                            City = "Zagazig",
                            GovernateId = 4
                        });
                });

            modelBuilder.Entity("Registration.Domain.Entities.GovernateCount", b =>
                {
                    b.Property<string>("Governate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserCount")
                        .HasColumnType("int");

                    b.HasKey("Governate");

                    b.ToTable("GovernateCounts");
                });

            modelBuilder.Entity("Registration.Domain.Entities.GovernateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("governates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Governate = "Cairo"
                        },
                        new
                        {
                            Id = 2,
                            Governate = "Giza"
                        },
                        new
                        {
                            Id = 3,
                            Governate = "Alexandria"
                        },
                        new
                        {
                            Id = 4,
                            Governate = "Sharqya"
                        },
                        new
                        {
                            Id = 5,
                            Governate = "Dakhalia"
                        });
                });

            modelBuilder.Entity("Registration.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Registration.Domain.Entities.Address", b =>
                {
                    b.HasOne("Registration.Domain.Entities.User", null)
                        .WithMany("AddressList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Registration.Domain.Entities.CityEntity", b =>
                {
                    b.HasOne("Registration.Domain.Entities.GovernateEntity", "Governate")
                        .WithMany("Cities")
                        .HasForeignKey("GovernateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governate");
                });

            modelBuilder.Entity("Registration.Domain.Entities.GovernateEntity", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Registration.Domain.Entities.User", b =>
                {
                    b.Navigation("AddressList");
                });
#pragma warning restore 612, 618
        }
    }
}
