using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class JobSiteContext : DbContext
    {
        public JobSiteContext()
        {
        }

        public JobSiteContext(DbContextOptions<JobSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<JobSeeker> JobSeeker { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<ReviewedVacancies> ReviewedVacancies { get; set; }
        public virtual DbSet<Summary> Summary { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=JobSite;Username=postgres;Password=sanches10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Job_seeker");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("position_name_index");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ReviewedVacancies>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reviewed_vacancies");

                entity.HasIndex(e => e.Date)
                    .HasName("reviewed_vacancies_date_index");

                entity.HasIndex(e => e.SummaryId)
                    .HasName("reviewed_vacancies_summary_id_index");

                entity.HasIndex(e => e.VacancyId)
                    .HasName("reviewed_vacancies_vacancy_id_index");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SummaryId).HasColumnName("Summary_id");

                entity.Property(e => e.VacancyId).HasColumnName("Vacancy_id");
            });

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.JobSeekerId).HasColumnName("Job_seeker_id");

                entity.Property(e => e.Summary1)
                    .IsRequired()
                    .HasColumnName("Summary");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.HasIndex(e => e.PositionId)
                    .HasName("vacancy_position_id_index");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EmployerId).HasColumnName("Employer_id");

                entity.Property(e => e.MaxSalary).HasColumnName("Max_salary");

                entity.Property(e => e.MinSalary).HasColumnName("Min_salary");

                entity.Property(e => e.PositionId).HasColumnName("Position_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
