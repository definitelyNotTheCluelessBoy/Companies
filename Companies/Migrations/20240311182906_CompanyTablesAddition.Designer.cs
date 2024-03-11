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
    [Migration("20240311182906_CompanyTablesAddition")]
    partial class CompanyTablesAddition
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
