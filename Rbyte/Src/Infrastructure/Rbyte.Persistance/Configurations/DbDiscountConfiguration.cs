using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbDiscountConfiguration : IEntityTypeConfiguration<DbDiscount>
    {
        public void Configure(EntityTypeBuilder<DbDiscount> builder)
        {
            builder.HasKey(x => x.DiscountId);

            builder.HasMany(x => x.DiscountProducts)
                    .WithOne(x => x.Discount)
                    .HasForeignKey(x => x.DiscountId);
        }
    }
}
