using System;
using Cargo4You.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cargo4You.BusinessObjects.SharedObjects
{
    public partial class Cargo4YouContext : DbContext, IDbContext
    {
        public Cargo4YouContext()
        {
        }

        public Cargo4YouContext(DbContextOptions<Cargo4YouContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calculation> Calculations { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Validation> Validations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-05AGSL7;Database=Cargo4You;User ID=sa;Password=v0xtene0;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Calculation>(entity =>
            {
                entity.ToTable("Calculation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstValue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecondValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Validation)
                    .WithMany(p => p.Calculations)
                    .HasForeignKey(d => d.ValidationId)
                    .HasConstraintName("FK__Calculati__Valid__2E1BDC42");
            });

            modelBuilder.Entity<Courier>(entity =>
            {
                entity.ToTable("Courier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Validation>(entity =>
            {
                entity.ToTable("Validation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstValue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Operator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecondValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Validations)
                    .HasForeignKey(d => d.CourierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Validatio__Couri__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
