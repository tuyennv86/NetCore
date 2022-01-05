using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.EF.Extensions;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertistmentPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
            // etc.
        }
    }
}