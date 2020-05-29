using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Jerry.Prateice.EF.DataBaseReserve.Models;

namespace Jerry.Prateice.EF.DataBaseReserve.Base
{
    public partial class LocalDbContext : DbContext
    {
        public LocalDbContext()
        {
        }

        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<t_class> t_class { get; set; }
        public virtual DbSet<t_classsubject> t_classsubject { get; set; }
        public virtual DbSet<t_student> t_student { get; set; }
        public virtual DbSet<t_subject> t_subject { get; set; }
        public virtual DbSet<t_teacher> t_teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;userid=root;pwd=123456;port=3306;database=prateice2;sslmode=none", x => x.ServerVersion("5.6.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClassName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<t_classsubject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClassId).HasColumnType("int(11)");

                entity.Property(e => e.SubjectId).HasColumnType("int(11)");

                entity.Property(e => e.TeacherId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<t_student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClassId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sex).HasColumnType("int(11)");
            });

            modelBuilder.Entity<t_subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<t_teacher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
