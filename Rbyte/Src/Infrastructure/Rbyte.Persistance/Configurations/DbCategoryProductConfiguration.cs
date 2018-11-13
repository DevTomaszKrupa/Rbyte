using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbCategoryProductConfiguration : IEntityTypeConfiguration<DbCategoryProduct>
    {
        public void Configure(EntityTypeBuilder<DbCategoryProduct> builder)
        {
            builder.HasKey(x => new
            {
                x.ProductId,
                x.CategoryId
            });
        }
    }
}
