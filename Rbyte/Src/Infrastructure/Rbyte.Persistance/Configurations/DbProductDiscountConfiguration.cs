using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbProductDiscountConfiguration : IEntityTypeConfiguration<DbProductDiscount>
    {
        public void Configure(EntityTypeBuilder<DbProductDiscount> builder)
        {
            builder.HasKey(x => new
            {
                x.ProductId,
                x.DiscountId
            });
        }
    }
}
