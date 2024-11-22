using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CarTypeConfiguration());
        }
    }
}

