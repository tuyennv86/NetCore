using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.EF.Extensions;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Data.EF.Configurations
{
    public class AdvertistmentPageConfiguration : DbEntityConfiguration<AdvertistmentPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}
