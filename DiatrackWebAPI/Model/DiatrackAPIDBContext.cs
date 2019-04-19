using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiatrackWebAPI.Model
{
    public partial class DiatrackAPIDBContext : DbContext
    {
        public DiatrackAPIDBContext()
        {
        }

        public DiatrackAPIDBContext(DbContextOptions<DiatrackAPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MealTypes> MealTypes { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<PatientReadings> PatientReadings { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderPatients> ProviderPatients { get; set; }
        public virtual DbSet<ReadingTypes> ReadingTypes { get; set; }
        public virtual DbSet<UserSponsor> UserSponsor { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:fadssdiatracksims.database.windows.net,1433;Initial Catalog=diaTrackSIMS;Persist Security Info=False;User ID=diatrackappuser;Password=z79T*pG!P&aV#N+W;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MealTypes>(entity =>
            {
                entity.HasKey(e => e.MealTypeId)
                    .HasName("PK__meal_typ__6F7616D835C019C5");

                entity.Property(e => e.MealTypeId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MealDesc).IsUnicode(false);
            });

            modelBuilder.Entity<Meals>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MealTypeId, e.MealDate })
                    .HasName("PK__meals__6BCF5171974E0435");

                entity.Property(e => e.MealTypeId).IsUnicode(false);

                entity.HasOne(d => d.MealType)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__meals__meal_type__06CD04F7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__meals__user_id__05D8E0BE");
            });

            modelBuilder.Entity<PatientReadings>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.ReadingTypeId, e.ReadingDate })
                    .HasName("PK__patient___699CB33D9C8FEFF1");

                entity.Property(e => e.ReadingTypeId).IsUnicode(false);

                entity.Property(e => e.ReadingValue).IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientReadings)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__patient_r__patie__18EBB532");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.ProviderId).ValueGeneratedOnAdd();

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Parish).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);

                entity.Property(e => e.Town).IsUnicode(false);

                entity.HasOne(d => d.ProviderNavigation)
                    .WithOne(p => p.Provider)
                    .HasForeignKey<Provider>(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__provider__provid__0F624AF8");
            });

            modelBuilder.Entity<ProviderPatients>(entity =>
            {
                entity.HasKey(e => new { e.ProviderId, e.PatientId })
                    .HasName("PK__provider__7437DD578246F4EC");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.ProviderPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__provider___patie__1332DBDC");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderPatients)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__provider___provi__123EB7A3");
            });

            modelBuilder.Entity<ReadingTypes>(entity =>
            {
                entity.HasKey(e => e.ReadingTypeId)
                    .HasName("PK__reading___993ABA4B25585D7E");

                entity.HasIndex(e => e.ReadingDesc)
                    .HasName("UQ__reading___4CEFAA534FB8AEF6")
                    .IsUnique();

                entity.Property(e => e.ReadingTypeId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ReadingDesc).IsUnicode(false);
            });

            modelBuilder.Entity<UserSponsor>(entity =>
            {
                entity.HasKey(e => new { e.SponsorId, e.PatientId })
                    .HasName("PK__user_spo__CAE21A132EE1B82D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.UserSponsorPatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_spon__patie__1CBC4616");

                entity.HasOne(d => d.Sponsor)
                    .WithMany(p => p.UserSponsorSponsor)
                    .HasForeignKey(d => d.SponsorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_spon__spons__1BC821DD");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK__user_typ__9424CFA6A4D7BDBF");

                entity.Property(e => e.UserTypeId)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserDesc).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__B9BE370F05BE8554");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserTypeId).IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__user_type__02FC7413");
            });
        }
    }
}
