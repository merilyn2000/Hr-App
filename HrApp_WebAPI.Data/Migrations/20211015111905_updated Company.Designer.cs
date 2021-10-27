﻿// <auto-generated />
using System;
using HrApp_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HrApp_WebAPI.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20211015111905_updated Company")]
    partial class updatedCompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HrApp_WebAPI.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfEstablishment")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.DriverLicense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InvalidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DriverLicense");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("DependentsId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonalDatasId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DependentsId");

                    b.HasIndex("PersonalDatasId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeAddresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeBankData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("IBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeBanca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("BankDatas");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Email")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("MicrosoftTeams")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalPhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("WorkPhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeContracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodInregistrare")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeDependents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumarPersoaneInIntretinere")
                        .HasColumnType("int");

                    b.Property<bool>("ScutireTaxe")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeIdentityDocuments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CIId")
                        .HasColumnType("int");

                    b.Property<int?>("DriverLicenseId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("PassportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CIId");

                    b.HasIndex("DriverLicenseId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PassportId");

                    b.ToTable("IdentityDocuments");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeePersonalDatas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalIdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalDatas");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeVersions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeContractsId")
                        .HasColumnType("int");

                    b.Property<string>("Hierarchy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Pozition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<DateTime>("VersionStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeContractsId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.IdentityCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InvalidFrom")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IdentityCard");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.Passport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InvalidFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Passport");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.Employee", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.HasOne("HrApp_WebAPI.Entities.EmployeeDependents", "Dependents")
                        .WithMany()
                        .HasForeignKey("DependentsId");

                    b.HasOne("HrApp_WebAPI.Entities.EmployeePersonalDatas", "PersonalDatas")
                        .WithMany()
                        .HasForeignKey("PersonalDatasId");

                    b.Navigation("Company");

                    b.Navigation("Dependents");

                    b.Navigation("PersonalDatas");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeAddresses", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.Employee", null)
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeBankData", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.Employee", null)
                        .WithMany("BankData")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeContacts", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.Employee", null)
                        .WithMany("Contacts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeContracts", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.Employee", null)
                        .WithMany("Contracts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeIdentityDocuments", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.IdentityCard", "CI")
                        .WithMany()
                        .HasForeignKey("CIId");

                    b.HasOne("HrApp_WebAPI.Entities.DriverLicense", "DriverLicense")
                        .WithMany()
                        .HasForeignKey("DriverLicenseId");

                    b.HasOne("HrApp_WebAPI.Entities.Employee", null)
                        .WithMany("IdentityDocuments")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("HrApp_WebAPI.Entities.Passport", "Passport")
                        .WithMany()
                        .HasForeignKey("PassportId");

                    b.Navigation("CI");

                    b.Navigation("DriverLicense");

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeVersions", b =>
                {
                    b.HasOne("HrApp_WebAPI.Entities.EmployeeContracts", null)
                        .WithMany("Versiuni")
                        .HasForeignKey("EmployeeContractsId");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.Employee", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("BankData");

                    b.Navigation("Contacts");

                    b.Navigation("Contracts");

                    b.Navigation("IdentityDocuments");
                });

            modelBuilder.Entity("HrApp_WebAPI.Entities.EmployeeContracts", b =>
                {
                    b.Navigation("Versiuni");
                });
#pragma warning restore 612, 618
        }
    }
}
