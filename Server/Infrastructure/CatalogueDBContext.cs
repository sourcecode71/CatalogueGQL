using Catalogue.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Server.Infrastructure
{
    public class CatalogueDBContext : DbContext
    {
        public CatalogueDBContext(DbContextOptions<CatalogueDBContext> options) : base(options)
        {

        }
        public DbSet<Course> Course => Set<Course>();
        public DbSet<School> School  => Set<School>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.Property(e => e.Id).IsUnicode(false);
                entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Code).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.SchoolId).IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity => {
                entity.ToTable("School");
                entity.Property(e => e.Id).IsUnicode(false);
                entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
                entity.Property(e=>e.Name).HasMaxLength(100).IsUnicode(false);
            });
        }
    }
}
