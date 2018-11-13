using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbProducerConfiguration : IEntityTypeConfiguration<DbProducer>
    {
        public void Configure(EntityTypeBuilder<DbProducer> builder)
        {
            builder.HasKey(x => x.ProducerId);

            builder.HasMany(x => x.Products)
                    .WithOne(x => x.Producer)
                    .HasForeignKey(x => x.ProducerId);
        }
    }
}
