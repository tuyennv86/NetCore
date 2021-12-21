using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.EF.Extensions;

namespace NetCoreApp.Data.EF.Configurations
{
    public class ProductTagConfiguration : ModelBuilderExtensions.DbEntityConfiguration<ProductTag>
    {
        public override void Configure(EntityTypeBuilder<ProductTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired().IsUnicode(false);
        }
    }
}
