//bridge between the code and the database
using Microsoft.EntityFrameworkCore;
using API1.Models;

namespace API1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the precision for the Price property in the Food entity
            modelBuilder.Entity<Food>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18,2)"); // 18 digits precision, 2 digits after the decimal point
        }
    }
}
