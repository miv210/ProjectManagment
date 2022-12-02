using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagment_WEBAPI.Models
{
    public partial class Project_ManagmentContext : DbContext
    {
        public Project_ManagmentContext()
        {
        }

        public Project_ManagmentContext(DbContextOptions<Project_ManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectsWorker> ProjectsWorkers { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MIV\\SQLEXPRESS;Database=Project_Managment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdManager).HasColumnName("id_manager");

                entity.Property(e => e.IdWorkeк).HasColumnName("id_workeк");

                entity.Property(e => e.NameCustomerCompany)
                    .HasMaxLength(150)
                    .HasColumnName("name_customer_company");

                entity.Property(e => e.NameImplementerCompany)
                    .HasMaxLength(150)
                    .HasColumnName("name_implementer_company");

                entity.Property(e => e.NameProject)
                    .HasMaxLength(50)
                    .HasColumnName("name_project");

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnType("date")
                    .HasColumnName("project_end_date");

                entity.Property(e => e.ProjectPriority).HasColumnName("project_priority");

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("date")
                    .HasColumnName("project_start_date");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("FK_Projects_Workers_Manager");
            });

            modelBuilder.Entity<ProjectsWorker>(entity =>
            {
                entity.ToTable("Projects_Workers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProject).HasColumnName("id_project");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectsWorkers)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("FK_Projects_Workers_Projects");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.ProjectsWorkers)
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("FK_Projects_Workers_Workers");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(100)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
