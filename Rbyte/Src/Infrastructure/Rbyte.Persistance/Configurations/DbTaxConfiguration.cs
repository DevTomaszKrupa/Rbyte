using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbTaxConfiguration : IEntityTypeConfiguration<DbTax>
    {
        public void Configure(EntityTypeBuilder<DbTax> builder)
        {
            builder.HasKey(x => x.TaxId);

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Tax)
                   .HasForeignKey(x => x.TaxId);
        }
    }
}