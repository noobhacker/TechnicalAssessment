using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssessment.Persistance
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureName>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Feature>()
               .HasIndex(p => new { p.Email, p.FeatureNameId })
               .IsUnique();
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureName> FeatureNames { get; set; }
    }
}
