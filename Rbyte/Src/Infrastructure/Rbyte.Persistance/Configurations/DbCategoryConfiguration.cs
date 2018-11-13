using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rbyte.Domain.Entities;

namespace Rbyte.Persistance.Configurations
{
    public class DbCategoryConfiguration : IEntityTypeConfiguration<DbCategory>
    {
        public void Configure(EntityTypeBuilder<DbCategory> builder)
        {
            builder.HasKey(x => x.CategoryId);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.HasMany(x => x.ChildernCategories)
                    .WithOne(x => x.ParentCategory)
                    .HasForeignKey(x => x.ParentCategoryId);

            builder.HasMany(x => x.CategoryProducts)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId);
        }
    }
}
