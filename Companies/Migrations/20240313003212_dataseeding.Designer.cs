﻿// <auto-generated />
using System;
using Companies.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Companies.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240313003212_dataseeding")]
    partial class dataseeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Companies.Models.Company", b =>
                {
                    b.Property<string>("IdCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DirectorOfNodeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCode");

                    b.HasIndex("DirectorOfNodeId");

                    b.ToTable("companies");

                    b.HasData(
                        new
                        {
                            IdCode = "001",
                            DirectorOfNodeId = 1,
                            Name = "First Company"
                        },
                        new
                        {
                            IdCode = "002",
                            DirectorOfNodeId = 2,
                            Name = "First Company"
                        });
                });

            modelBuilder.Entity("Companies.Models.Department", b =>
                {
                    b.Property<string>("IdCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DirectorOfNodeId")
                        .HasColumnType("int");

                    b.Property<string>("MotherProjectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCode");

                    b.HasIndex("DirectorOfNodeId");

                    b.HasIndex("MotherProjectId");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            IdCode = "001",
                            DirectorOfNodeId = 7,
                            MotherProjectId = "001",
                            Name = "First Department"
                        },
                        new
                        {
                            IdCode = "002",
                            DirectorOfNodeId = 8,
                            MotherProjectId = "002",
                            Name = "Second Department"
                        });
                });

            modelBuilder.Entity("Companies.Models.Division", b =>
                {
                    b.Property<string>("IdCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DirectorOfNodeId")
                        .HasColumnType("int");

                    b.Property<string>("MotherCompanyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCode");

                    b.HasIndex("DirectorOfNodeId");

                    b.HasIndex("MotherCompanyId");

                    b.ToTable("divisions");

                    b.HasData(
                        new
                        {
                            IdCode = "001",
                            DirectorOfNodeId = 3,
                            MotherCompanyId = "001",
                            Name = "First division"
                        },
                        new
                        {
                            IdCode = "002",
                            DirectorOfNodeId = 4,
                            MotherCompanyId = "002",
                            Name = "Second division"
                        });
                });

            modelBuilder.Entity("Companies.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "janonovak@email.com",
                            FirstName = "Jano",
                            LastName = "Novák",
                            Phone = "+421999888777"
                        },
                        new
                        {
                            Id = 2,
                            Email = "petermali@email.com",
                            FirstName = "Peter",
                            LastName = "Malí",
                            Phone = "+421999888666",
                            Title = "Mgr."
                        },
                        new
                        {
                            Id = 3,
                            Email = "frantisekstromkoc@email.com",
                            FirstName = "František",
                            LastName = "Stromokocur",
                            Phone = "+421999888555",
                            Title = "Ing."
                        },
                        new
                        {
                            Id = 4,
                            Email = "jaropecka@email.com",
                            FirstName = "Jaroslav",
                            LastName = "Pecka",
                            Phone = "+421999222777"
                        },
                        new
                        {
                            Id = 5,
                            Email = "ivkafialka@email.com",
                            FirstName = "Iveta",
                            LastName = "Fialova",
                            Phone = "+421888888777",
                            Title = "Doc."
                        },
                        new
                        {
                            Id = 6,
                            Email = "hrasko.janko@email.com",
                            FirstName = "Janko",
                            LastName = "Hrasko",
                            Phone = "+421999888677"
                        },
                        new
                        {
                            Id = 7,
                            Email = "topsecret@misix.com",
                            FirstName = "James",
                            LastName = "Bond",
                            Phone = "+421000000007"
                        },
                        new
                        {
                            Id = 8,
                            Email = "unknown@mistery.com",
                            FirstName = "Jhon",
                            LastName = "Doe",
                            Phone = "+421000000000",
                            Title = "Magician"
                        });
                });

            modelBuilder.Entity("Companies.Models.Project", b =>
                {
                    b.Property<string>("IdCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DirectorOfNodeId")
                        .HasColumnType("int");

                    b.Property<string>("MotherDivisionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCode");

                    b.HasIndex("DirectorOfNodeId");

                    b.HasIndex("MotherDivisionId");

                    b.ToTable("projects");

                    b.HasData(
                        new
                        {
                            IdCode = "001",
                            DirectorOfNodeId = 5,
                            MotherDivisionId = "001",
                            Name = "First project"
                        },
                        new
                        {
                            IdCode = "002",
                            DirectorOfNodeId = 6,
                            MotherDivisionId = "002",
                            Name = "Second project"
                        });
                });

            modelBuilder.Entity("Companies.Models.Company", b =>
                {
                    b.HasOne("Companies.Models.Employee", "DirectorOfNode")
                        .WithMany()
                        .HasForeignKey("DirectorOfNodeId");

                    b.Navigation("DirectorOfNode");
                });

            modelBuilder.Entity("Companies.Models.Department", b =>
                {
                    b.HasOne("Companies.Models.Employee", "DirectorOfNode")
                        .WithMany()
                        .HasForeignKey("DirectorOfNodeId");

                    b.HasOne("Companies.Models.Project", "MotherProject")
                        .WithMany("ListOdDepartments")
                        .HasForeignKey("MotherProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectorOfNode");

                    b.Navigation("MotherProject");
                });

            modelBuilder.Entity("Companies.Models.Division", b =>
                {
                    b.HasOne("Companies.Models.Employee", "DirectorOfNode")
                        .WithMany()
                        .HasForeignKey("DirectorOfNodeId");

                    b.HasOne("Companies.Models.Company", "MotherCompany")
                        .WithMany("divisionsOfCompany")
                        .HasForeignKey("MotherCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectorOfNode");

                    b.Navigation("MotherCompany");
                });

            modelBuilder.Entity("Companies.Models.Project", b =>
                {
                    b.HasOne("Companies.Models.Employee", "DirectorOfNode")
                        .WithMany()
                        .HasForeignKey("DirectorOfNodeId");

                    b.HasOne("Companies.Models.Division", "MotherDivision")
                        .WithMany("listOfProjects")
                        .HasForeignKey("MotherDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectorOfNode");

                    b.Navigation("MotherDivision");
                });

            modelBuilder.Entity("Companies.Models.Company", b =>
                {
                    b.Navigation("divisionsOfCompany");
                });

            modelBuilder.Entity("Companies.Models.Division", b =>
                {
                    b.Navigation("listOfProjects");
                });

            modelBuilder.Entity("Companies.Models.Project", b =>
                {
                    b.Navigation("ListOdDepartments");
                });
#pragma warning restore 612, 618
        }
    }
}