using BiahsJewels.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiahsJewels.Mvc.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

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
        modelBuilder.Entity<Product>()
            .HasOne(pi => pi.Category)
            .WithMany(pc => pc.Products)
            .HasForeignKey(pi => pi.CategoryId) // Foreign key property in Products
            .OnDelete(DeleteBehavior.Cascade); // Specify the delete behavior (Cascade)
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<IdentityUser>(entity => {
            entity.ToTable(name: "Users");
        });
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable(name: "UserRoles");
        });
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable(name: "RoleClaims");
        });
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable(name: "UserClaims");
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable(name: "UserLogins");
        });
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable(name: "UserTokens");
        });
    }
}
