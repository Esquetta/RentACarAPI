﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20230130164332_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Security.Entities.EmailAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActivationKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAuthenticators");
                });

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4075),
                            Name = "Admin",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4075)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4077),
                            Name = "Moderator",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4077)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4077),
                            Name = "Customer",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4078)
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4078),
                            Name = "Manager",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4078)
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4079),
                            Name = "Employee",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(4079)
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.OtpAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<byte[]>("SecretKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OtpAuthenticators");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Audi",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1469),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1471)
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "Ford",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1474),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1474)
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "Nissan",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1474),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1475)
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "Toyata",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1475),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1475)
                        },
                        new
                        {
                            Id = 5,
                            BrandName = "BMW",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1476),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1476)
                        },
                        new
                        {
                            Id = 6,
                            BrandName = "Mercedes",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1476),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1477)
                        },
                        new
                        {
                            Id = 7,
                            BrandName = "Porche",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1477),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1478)
                        },
                        new
                        {
                            Id = 8,
                            BrandName = "Doge",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1478),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1478)
                        },
                        new
                        {
                            Id = 9,
                            BrandName = "Ferrari",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1479),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1479)
                        },
                        new
                        {
                            Id = 10,
                            BrandName = "Lamborghini",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1479),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1480)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CarColorId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModelId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("CarState")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuelId")
                        .HasColumnType("int");

                    b.Property<int>("GearBoxId")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Miles")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarColorId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("FuelId");

                    b.HasIndex("GearBoxId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CarColors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Blue",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1701),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1702)
                        },
                        new
                        {
                            Id = 2,
                            Color = "Red",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1703),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1703)
                        },
                        new
                        {
                            Id = 3,
                            Color = "Yellow",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1704),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1704)
                        },
                        new
                        {
                            Id = 4,
                            Color = "White",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1705),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1705)
                        },
                        new
                        {
                            Id = 5,
                            Color = "Black",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1706),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1706)
                        },
                        new
                        {
                            Id = 6,
                            Color = "Green",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1706),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1707)
                        },
                        new
                        {
                            Id = 7,
                            Color = "Metalic Grey",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1707),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1707)
                        },
                        new
                        {
                            Id = 8,
                            Color = "Midnight Purple",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1708),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1708)
                        },
                        new
                        {
                            Id = 9,
                            Color = "Orange",
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1708),
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(1709)
                        });
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3626),
                            ModelName = "A4",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3627)
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3628),
                            ModelName = "Focus RS",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3629)
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3629),
                            ModelName = "GTR",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3629)
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3630),
                            ModelName = "Supra",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3630)
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 5,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3631),
                            ModelName = "M5",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3631)
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 6,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3632),
                            ModelName = "AMG GTR",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3632)
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 7,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3633),
                            ModelName = "GT3",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3633)
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 8,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3634),
                            ModelName = "Charger",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3634)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Fuels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3821),
                            FuelType = "Gasoline",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3822)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3823),
                            FuelType = "Motorine",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3824)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3824),
                            FuelType = "Electrical",
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3824)
                        });
                });

            modelBuilder.Entity("Domain.Entities.GearBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GearType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GearBoxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3944),
                            GearType = "Manual",
                            Speed = 6,
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3944)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3945),
                            GearType = "Automatic",
                            Speed = 6,
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3945)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3946),
                            GearType = "Half-Automatic",
                            Speed = 6,
                            UpdatedDate = new DateTime(2023, 1, 30, 16, 43, 32, 117, DateTimeKind.Utc).AddTicks(3946)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Domain.Entities.RentDetail", b =>
                {
                    b.Property<int>("RentId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("RentId", "CarId");

                    b.HasIndex("CarId");

                    b.ToTable("RentDetails");
                });

            modelBuilder.Entity("Core.Security.Entities.EmailAuthenticator", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.OtpAuthenticator", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CarColor", "CarColor")
                        .WithMany()
                        .HasForeignKey("CarColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Fuel", "Fuel")
                        .WithMany("Cars")
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.GearBox", "GearBox")
                        .WithMany("Cars")
                        .HasForeignKey("GearBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("CarColor");

                    b.Navigation("CarModel");

                    b.Navigation("Fuel");

                    b.Navigation("GearBox");
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("CarModels")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.Photo", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("Photos")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Rent", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.RentDetail", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("RendDetails")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Rent", "Rent")
                        .WithMany()
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Rent");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("CarModels");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("RendDetails");
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.Fuel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.GearBox", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}