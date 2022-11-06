using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Models;

namespace RAShop.Backend.Data
{
    public class RAShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        public RAShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasMany<Product>(p => p.Products)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubCategory>()
            .HasMany<Product>(p => p.Products)
            .WithOne(c => c.SubCategory)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasMany<SubCategory>(s => s.SubCates)
                .WithOne(s => s.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
