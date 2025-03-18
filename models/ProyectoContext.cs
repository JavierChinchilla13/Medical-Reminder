using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoMedicamento.Models
{
    public partial class ProyectoContext : DbContext
    {
        public ProyectoContext()
        {
        }

        public ProyectoContext(DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<LogMed> LogMeds { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Med> Meds { get; set; } = null!;
        public virtual DbSet<Med1> Meds1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI-GF63-THIN;Database=Proyecto;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Users).HasColumnType("text");
            });

            modelBuilder.Entity<LogMed>(entity =>
            {
                entity.ToTable("Log_Med");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.IdMed).HasColumnName("idMed");

                entity.HasOne(d => d.IdLogNavigation)
                    .WithMany(p => p.LogMeds)
                    .HasForeignKey(d => d.IdLog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_Med");

                entity.HasOne(d => d.IdMedNavigation)
                    .WithMany(p => p.LogMeds)
                    .HasForeignKey(d => d.IdMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log_Med_Med");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Mail);

                entity.ToTable("Login");

                entity.Property(e => e.Mail)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Users).HasColumnType("text");
            });

            modelBuilder.Entity<Med>(entity =>
            {
                entity.ToTable("Med");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateM).HasMaxLength(50);

                

                entity.Property(e => e.NameM).HasColumnType("text");

                entity.Property(e => e.ScheduleM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeM)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Med1>(entity =>
            {
                entity.HasKey(e => e.TypeM);

                entity.ToTable("Meds");

                entity.Property(e => e.TypeM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameM).HasColumnType("text");

                entity.Property(e => e.ScheduleM)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
