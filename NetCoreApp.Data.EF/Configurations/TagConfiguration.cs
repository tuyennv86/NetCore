using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.EF.Extensions;

namespace NetCoreApp.Data.EF.Configurations
{
    public class TagConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Tag>
    {        
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired().IsUnicode(false);
        }
    }
}