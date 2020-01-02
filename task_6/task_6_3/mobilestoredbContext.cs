using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task_6_3
{
    public partial class mobilestoredbContext : DbContext
    {
        public mobilestoredbContext()
        {
        }

        public mobilestoredbContext(DbContextOptions<mobilestoredbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> NewOrders { get; set; }
        public virtual DbSet<Phones> NewPhones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mobilestoredb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.PhoneId);

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PhoneId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
