﻿// <auto-generated />
using System;
using LianAgentPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LianAgentPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231108032212_TableAutomobile")]
    partial class TableAutomobile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceAutomobileDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AgentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Attributes_Category")
                        .HasColumnType("int");

                    b.Property<string>("Attributes_Seat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AutomobilesType")
                        .HasColumnType("int");

                    b.Property<string>("CertificateDigitalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long>("InsuranceMasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LiabilityInsuranceFee")
                        .HasColumnType("bigint");

                    b.Property<string>("LicensePlates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerTransaction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PassengerCount")
                        .HasColumnType("bigint");

                    b.Property<long>("PassengerFee")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeCoverage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceMasterId");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.ToTable("InsuranceAutomobileDetails");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceFamilyBreadwinnerDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AgentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Birhtday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CertificateDigitalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InsuranceMasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerTransaction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeCoverage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceMasterId");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.ToTable("InsuranceFamilyBreadwinnerDetails");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1001L);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastDateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUserUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalInsuranceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalIssuedRows")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPremium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalRows")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserCreate")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DateCreate");

                    b.HasIndex("Type");

                    b.HasIndex("UserCreate");

                    b.ToTable("InsuranceMasters");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceMotorDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AgentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Birhtday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CertificateDigitalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InsuranceMasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicensePlates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MotorType")
                        .HasColumnType("int");

                    b.Property<string>("PartnerTransaction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PassengerInsurance")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeCoverage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceMasterId");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.ToTable("InsuranceMotorDetails");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsurancePersonalAccidentDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AgentPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Birhtday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CertificateDigitalLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InsuranceMasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerTransaction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranking")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeCoverage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceMasterId");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.ToTable("InsurancePersonalAccidentDetails");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.LianAgent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AppId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistedPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LianAgents");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AppId = "27472747",
                            Description = "VASS - SANDBOX",
                            Name = "VASS - SANDBOX",
                            RegistedPhone = "0962473427",
                            SecretKey = "3af4df1274fcf5b2ecfe2098e00facf7"
                        });
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.LianUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("GoogleAuthenticatorSecretCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<long?>("LianAgentId")
                        .HasColumnType("bigint");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LianAgentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "00000000-0000-0000-0000-000000000001",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3f4073e-32fe-4114-a35f-3c006bd1be11",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "0962473427",
                            EmailConfirmed = true,
                            GoogleAuthenticatorSecretCode = "ABB80D77",
                            IsActivated = true,
                            LianAgentId = 1L,
                            LockoutEnabled = false,
                            NormalizedEmail = "0962473427",
                            NormalizedUserName = "0962473427",
                            PasswordHash = "AQAAAAIAAYagAAAAEDFipV5tc8aoO5e+HBUe73+LurpMM1QIEZxLkE38b6JPyaohZh7wYDRo4Gv8rV3xAw==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "0962473427"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "00000000-0000-0000-0000-000000000001",
                            Name = "ADMIN_ROLE",
                            NormalizedName = "ADMIN_ROLE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "00000000-0000-0000-0000-000000000001",
                            RoleId = "00000000-0000-0000-0000-000000000001"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceAutomobileDetail", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.InsuranceMaster", "InsuranceMaster")
                        .WithMany()
                        .HasForeignKey("InsuranceMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsuranceMaster");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceFamilyBreadwinnerDetail", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.InsuranceMaster", "InsuranceMaster")
                        .WithMany()
                        .HasForeignKey("InsuranceMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsuranceMaster");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsuranceMotorDetail", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.InsuranceMaster", "InsuranceMaster")
                        .WithMany()
                        .HasForeignKey("InsuranceMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsuranceMaster");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.InsurancePersonalAccidentDetail", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.InsuranceMaster", "InsuranceMaster")
                        .WithMany()
                        .HasForeignKey("InsuranceMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsuranceMaster");
                });

            modelBuilder.Entity("LianAgentPortal.Models.DbModels.LianUser", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.LianAgent", "LianAgent")
                        .WithMany()
                        .HasForeignKey("LianAgentId");

                    b.Navigation("LianAgent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.LianUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.LianUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LianAgentPortal.Models.DbModels.LianUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LianAgentPortal.Models.DbModels.LianUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
