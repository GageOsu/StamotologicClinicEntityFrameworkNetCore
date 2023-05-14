using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StamotologicClinic.Models;

public partial class StomatologicClinicContext : DbContext
{
    public StomatologicClinicContext()
    {
    }

    public StomatologicClinicContext(DbContextOptions<StomatologicClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<MedicalPersonnel> MedicalPersonnels { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<RecordHistory> RecordHistories { get; set; }

    public virtual DbSet<TypeService> TypeServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DANIILMOROZOV;Database=StomatologicClinic;Trusted_Connection=true;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Idaccount).HasName("PK_Accounts_1");

            entity.HasIndex(e => e.Login, "IX_Accounts").IsUnique();

            entity.Property(e => e.Idaccount).HasColumnName("IDAccount");
            entity.Property(e => e.IdmedicalPersonnel).HasColumnName("IDMedicalPersonnel");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdmedicalPersonnelNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdmedicalPersonnel)
                .HasConstraintName("FK_Accounts_MedicalPersonnels");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Idadress);

            entity.Property(e => e.Idadress).HasColumnName("IDAdress");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.House)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Locality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory);

            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<MedicalPersonnel>(entity =>
        {
            entity.HasKey(e => e.IdmedicalPersonnel);

            entity.Property(e => e.IdmedicalPersonnel).HasColumnName("IDMedicalPersonnel");
            entity.Property(e => e.Idposition).HasColumnName("IDPosition");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdpositionNavigation).WithMany(p => p.MedicalPersonnel)
                .HasForeignKey(d => d.Idposition)
                .HasConstraintName("FK_MedicalPersonnels_Positions");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Idpatient);

            entity.HasIndex(e => e.PhoneNumber, "IX_Patients").IsUnique();

            entity.HasIndex(e => e.Mhipolicy, "IX_Patients_1").IsUnique();

            entity.Property(e => e.Idpatient).HasColumnName("IDPatient");
            entity.Property(e => e.Idadress).HasColumnName("IDAdress");
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mhipolicy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MHIPolicy");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdadressNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Idadress)
                .HasConstraintName("FK_Patients_Addresses");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Idposition);

            entity.HasIndex(e => e.Position1, "IX_Positions").IsUnique();

            entity.Property(e => e.Idposition).HasColumnName("IDPosition");
            entity.Property(e => e.Position1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Position");
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.Idchanges);

            entity.ToTable("PriceHistory");

            entity.Property(e => e.Idchanges).HasColumnName("IDChanges");
            entity.Property(e => e.DateChange).HasColumnType("date");
            entity.Property(e => e.Idservice).HasColumnName("IDService");
            entity.Property(e => e.NewPrices).HasColumnType("money");
            entity.Property(e => e.OldPrices).HasColumnType("money");

            entity.HasOne(d => d.IdserviceNavigation).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.Idservice)
                .HasConstraintName("FK_PriceHistory_TypeServices");
        });

        modelBuilder.Entity<RecordHistory>(entity =>
        {
            entity.HasKey(e => e.Idrecord);

            entity.ToTable("RecordHistory");

            entity.Property(e => e.Idrecord).HasColumnName("IDRecord");
            entity.Property(e => e.DateRegistration).HasColumnType("date");
            entity.Property(e => e.DateСompletion).HasColumnType("date");
            entity.Property(e => e.IdmedicalPersonal).HasColumnName("IDMedicalPersonal");
            entity.Property(e => e.Idpatient).HasColumnName("IDPatient");
            entity.Property(e => e.Idservice).HasColumnName("IDService");

            entity.HasOne(d => d.IdmedicalPersonalNavigation).WithMany(p => p.RecordHistories)
                .HasForeignKey(d => d.IdmedicalPersonal)
                .HasConstraintName("FK_RecordHistory_MedicalPersonnels");

            entity.HasOne(d => d.IdpatientNavigation).WithMany(p => p.RecordHistories)
                .HasForeignKey(d => d.Idpatient)
                .HasConstraintName("FK_RecordHistory_Patients");

            entity.HasOne(d => d.IdserviceNavigation).WithMany(p => p.RecordHistories)
                .HasForeignKey(d => d.Idservice)
                .HasConstraintName("FK_RecordHistory_TypeServices");
        });

        modelBuilder.Entity<TypeService>(entity =>
        {
            entity.HasKey(e => e.Idservice);

            entity.ToTable(tb => tb.HasTrigger("PriceUpdate"));

            entity.Property(e => e.Idservice).HasColumnName("IDService");
            entity.Property(e => e.DescriptionService)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.TypeServices)
                .HasForeignKey(d => d.Idcategory)
                .HasConstraintName("FK_TypeServices_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
