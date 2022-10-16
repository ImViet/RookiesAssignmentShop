using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Models;
namespace RAShop.Backend.Data
{
    public class RAShopDbContext: DbContext 
    {
        private DbSet<Product> Products { get; set; }
        private DbSet<Category> Categories { get; set; }
        private DbSet<ProductImage> ProductImages { get; set; }
        private DbSet<Order> Orders { get; set; }
        private DbSet<OrderDetail> OrderDetails { get; set; }

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
        }
    }
}
