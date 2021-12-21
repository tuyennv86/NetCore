using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.EF.Extensions;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Data.EF.Configurations
{
    public class AdvertisementPositionConfiguration : ModelBuilderExtensions.DbEntityConfiguration<AdvertisementPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired().IsUnicode(false);
        }
    }
}