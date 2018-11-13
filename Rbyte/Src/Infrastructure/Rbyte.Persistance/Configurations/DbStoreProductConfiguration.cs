using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbStoreProductConfiguration : IEntityTypeConfiguration<DbStoreProduct>
    {
        public void Configure(EntityTypeBuilder<DbStoreProduct> builder)
        {
            builder.HasKey(x => new
            {
                x.ProductId,
                x.StoreId
            });
        }
    }
}
