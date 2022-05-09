using CatalogueGQL.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogueGQL.Server.Infrastructure
{
    public class CatalogueDBContext : DbContext
    {
        public CatalogueDBContext(DbContextOptions<CatalogueDBContext> options) : base(options)
        {

        }
        public DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Major> Major { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Major>()
                .HasMany(c => c.Courses)
                .WithOne(p => p.Major)
                .HasForeignKey(p => p.MajorId);

            modelBuilder.Entity<Courses>()
                .HasOne(p => p.Major)
                .WithMany(c => c.Courses)
                .HasForeignKey(p=>p.MajorId);
        }
    }
}
