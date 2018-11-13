using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbStoreConfiguration : IEntityTypeConfiguration<DbStore>
    {
        public void Configure(EntityTypeBuilder<DbStore> builder)
        {
            builder.HasKey(x => x.StoreId);
        }
    }
}
