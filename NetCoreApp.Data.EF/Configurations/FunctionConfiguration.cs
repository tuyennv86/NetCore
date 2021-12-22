using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreApp.Data.EF.Extensions;
using NetCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApp.Data.EF.Configurations
{
    class FunctionConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Function>
    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(50).IsRequired().IsUnicode(false);
        }
    }
}
