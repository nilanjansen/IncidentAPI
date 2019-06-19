using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeltaEndpoint.Models
{
    public partial class deltastoreContext : DbContext
    {
        public deltastoreContext()
        {
        }

        public deltastoreContext(DbContextOptions<deltastoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incident> Incident { get; set; }
        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = GetConnectionString();
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.Property(e => e.IncidentId).ValueGeneratedNever();

                entity.Property(e => e.CreatorContact)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IssueType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
