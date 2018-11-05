using Microsoft.EntityFrameworkCore;
using Rbyte.Models;

namespace Rbyte
{
    public class RbyteContext : DbContext
    {
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbShop> Shops { get; set; }
        public DbSet<DbShopProduct> ShopProducts { get; set; }
        public DbSet<DbUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=rByte;user=root;password=admin");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<DbProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Name)
                      .IsRequired();
                entity.HasMany(p => p.ProductShops)
                      .WithOne(d => d.Product)
                      .HasForeignKey(d => d.ProductId);
            });

            builder.Entity<DbShopProduct>(e =>
            {
                e.HasKey(x => new
                {
                    x.ProductId,
                    x.ShopId
                });
            });

            builder.Entity<DbShop>(entity =>
            {
                entity.HasKey(e => e.ShopId);
                entity.HasMany(d => d.ShopProducts)
                      .WithOne(p => p.Shop)
                      .HasForeignKey(p => p.ShopId);
            });

            builder.Entity<DbUser>(e =>
            {
                e.HasKey(x => x.UserId);
            });
        }
    }
}
