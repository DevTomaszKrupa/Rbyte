using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Persistance.Extensions;

namespace Rbyte.Persistance
{
    public class RbyteContext : DbContext
    {
        public RbyteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DbCategory> Categories { get; set; }
        public DbSet<DbCategoryProduct> CategoryProducts { get; set; }
        public DbSet<DbDiscount> Discounts { get; set; }
        public DbSet<DbProducer> Producers { get; set; }
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbProductDiscount> ProductDiscounts { get; set; }
        public DbSet<DbStore> Stores { get; set; }
        public DbSet<DbStoreProduct> StoreProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
