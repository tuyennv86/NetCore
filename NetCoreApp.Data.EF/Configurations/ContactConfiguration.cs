using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.EF.Extensions;
using NetCoreApp.Data.Entities;

namespace NetCoreApp.Data.EF.Configurations
{
    public class ContactConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(256).IsRequired().IsUnicode(false);
        }
    }
}