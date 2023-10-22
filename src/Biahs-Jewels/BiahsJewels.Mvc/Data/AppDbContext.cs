using BiahsJewels.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BiahsJewels.Mvc.Data;

public class AppDbContext : DbContext
{
    DbSet<Product> ProductItem { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
       .Property(p => p.Price)
       .HasColumnType("decimal(18, 2)"); // Specifies decimal column with precision 18 and scale 2

        modelBuilder.Entity<Product>()
            .Property(p => p.Rating)
            .HasColumnType("decimal(5, 2)"); // Specifies decimal column with precision 5 and scale 2
    }
}
