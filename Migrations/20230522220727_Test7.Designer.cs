﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StamotologicClinic.Models;

#nullable disable

namespace StamotologicClinic.Migrations
{
    [DbContext(typeof(StomatologicClinicContext))]
    [Migration("20230522220727_Test7")]
    partial class Test7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StamotologicClinic.Models.Account", b =>
                {
                    b.Property<int>("Idaccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDAccount");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idaccount"));

                    b.Property<int?>("IdmedicalPersonnel")
                        .HasColumnType("int")
                        .HasColumnName("IDMedicalPersonnel");

                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Idaccount")
                        .HasName("PK_Accounts_1");

                    b.HasIndex("IdmedicalPersonnel");

                    b.HasIndex(new[] { "Login" }, "IX_Accounts")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Address", b =>
                {
                    b.Property<int>("Idadress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDAdress");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idadress"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("District")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("House")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Locality")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Idadress");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Category", b =>
                {
                    b.Property<int>("Idcategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idcategory"));

                    b.Property<string>("Category1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Category");

                    b.HasKey("Idcategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StamotologicClinic.Models.MedicalPersonnel", b =>
                {
                    b.Property<int>("IdmedicalPersonnel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDMedicalPersonnel");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdmedicalPersonnel"));

                    b.Property<int?>("Idposition")
                        .HasColumnType("int")
                        .HasColumnName("IDPosition");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdmedicalPersonnel");

                    b.HasIndex("Idposition");

                    b.ToTable("MedicalPersonnels");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Patient", b =>
                {
                    b.Property<int>("Idpatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPatient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idpatient"));

                    b.Property<int?>("Idadress")
                        .HasColumnType("int")
                        .HasColumnName("IDAdress");

                    b.Property<string>("InsuranceCompany")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mhipolicy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("MHIPolicy");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Sex")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Idpatient");

                    b.HasIndex("Idadress");

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_Patients")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex(new[] { "Mhipolicy" }, "IX_Patients_1")
                        .IsUnique()
                        .HasFilter("[MHIPolicy] IS NOT NULL");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Position", b =>
                {
                    b.Property<int>("Idposition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDPosition");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idposition"));

                    b.Property<string>("Position1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Position");

                    b.HasKey("Idposition");

                    b.HasIndex(new[] { "Position1" }, "IX_Positions")
                        .IsUnique()
                        .HasFilter("[Position] IS NOT NULL");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("StamotologicClinic.Models.PriceHistory", b =>
                {
                    b.Property<int>("Idchanges")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDChanges");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idchanges"));

                    b.Property<DateTime?>("DateChange")
                        .HasColumnType("date");

                    b.Property<int?>("Idservice")
                        .HasColumnType("int")
                        .HasColumnName("IDService");

                    b.Property<decimal?>("NewPrices")
                        .HasColumnType("money");

                    b.Property<decimal?>("OldPrices")
                        .HasColumnType("money");

                    b.HasKey("Idchanges");

                    b.HasIndex("Idservice");

                    b.ToTable("PriceHistory", (string)null);
                });

            modelBuilder.Entity("StamotologicClinic.Models.RecordHistory", b =>
                {
                    b.Property<int>("Idrecord")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDRecord");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idrecord"));

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateRegistration")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateСompletion")
                        .HasColumnType("date");

                    b.Property<int?>("IdmedicalPersonal")
                        .HasColumnType("int")
                        .HasColumnName("IDMedicalPersonal");

                    b.Property<int?>("Idpatient")
                        .HasColumnType("int")
                        .HasColumnName("IDPatient");

                    b.Property<int?>("Idservice")
                        .HasColumnType("int")
                        .HasColumnName("IDService");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idrecord");

                    b.HasIndex("IdmedicalPersonal");

                    b.HasIndex("Idpatient");

                    b.HasIndex("Idservice");

                    b.ToTable("RecordHistory", (string)null);
                });

            modelBuilder.Entity("StamotologicClinic.Models.TypeService", b =>
                {
                    b.Property<int>("Idservice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IDService");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idservice"));

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionService")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Idcategory")
                        .HasColumnType("int")
                        .HasColumnName("IDCategory");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("Idservice");

                    b.HasIndex("Idcategory");

                    b.ToTable("TypeServices", t =>
                        {
                            t.HasTrigger("PriceUpdate");
                        });
                });

            modelBuilder.Entity("StamotologicClinic.Models.Account", b =>
                {
                    b.HasOne("StamotologicClinic.Models.MedicalPersonnel", "IdmedicalPersonnelNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("IdmedicalPersonnel")
                        .HasConstraintName("FK_Accounts_MedicalPersonnels");

                    b.Navigation("IdmedicalPersonnelNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.MedicalPersonnel", b =>
                {
                    b.HasOne("StamotologicClinic.Models.Position", "IdpositionNavigation")
                        .WithMany("MedicalPersonnel")
                        .HasForeignKey("Idposition")
                        .HasConstraintName("FK_MedicalPersonnels_Positions");

                    b.Navigation("IdpositionNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Patient", b =>
                {
                    b.HasOne("StamotologicClinic.Models.Address", "IdadressNavigation")
                        .WithMany("Patients")
                        .HasForeignKey("Idadress")
                        .HasConstraintName("FK_Patients_Addresses");

                    b.Navigation("IdadressNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.PriceHistory", b =>
                {
                    b.HasOne("StamotologicClinic.Models.TypeService", "IdserviceNavigation")
                        .WithMany("PriceHistories")
                        .HasForeignKey("Idservice")
                        .HasConstraintName("FK_PriceHistory_TypeServices");

                    b.Navigation("IdserviceNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.RecordHistory", b =>
                {
                    b.HasOne("StamotologicClinic.Models.MedicalPersonnel", "IdmedicalPersonalNavigation")
                        .WithMany("RecordHistories")
                        .HasForeignKey("IdmedicalPersonal")
                        .HasConstraintName("FK_RecordHistory_MedicalPersonnels");

                    b.HasOne("StamotologicClinic.Models.Patient", "IdpatientNavigation")
                        .WithMany("RecordHistories")
                        .HasForeignKey("Idpatient")
                        .HasConstraintName("FK_RecordHistory_Patients");

                    b.HasOne("StamotologicClinic.Models.TypeService", "IdserviceNavigation")
                        .WithMany("RecordHistories")
                        .HasForeignKey("Idservice")
                        .HasConstraintName("FK_RecordHistory_TypeServices");

                    b.Navigation("IdmedicalPersonalNavigation");

                    b.Navigation("IdpatientNavigation");

                    b.Navigation("IdserviceNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.TypeService", b =>
                {
                    b.HasOne("StamotologicClinic.Models.Category", "IdcategoryNavigation")
                        .WithMany("TypeServices")
                        .HasForeignKey("Idcategory")
                        .HasConstraintName("FK_TypeServices_Categories");

                    b.Navigation("IdcategoryNavigation");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Address", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Category", b =>
                {
                    b.Navigation("TypeServices");
                });

            modelBuilder.Entity("StamotologicClinic.Models.MedicalPersonnel", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("RecordHistories");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Patient", b =>
                {
                    b.Navigation("RecordHistories");
                });

            modelBuilder.Entity("StamotologicClinic.Models.Position", b =>
                {
                    b.Navigation("MedicalPersonnel");
                });

            modelBuilder.Entity("StamotologicClinic.Models.TypeService", b =>
                {
                    b.Navigation("PriceHistories");

                    b.Navigation("RecordHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
