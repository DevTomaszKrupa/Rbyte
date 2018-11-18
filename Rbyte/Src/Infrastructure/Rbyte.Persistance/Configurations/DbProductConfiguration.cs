using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbProductConfiguration : IEntityTypeConfiguration<DbProduct>
    {
        public void Configure(EntityTypeBuilder<DbProduct> builder)
        {
            builder.HasKey(x => x.ProductId);
            
            builder.Property(x => x.ProductId)
                   .ValueGeneratedOnAdd();

            builder.HasMany(x => x.ProductDiscounts)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductCategories)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductStores)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);
        }
    }
}
