using Kalakobana.Domain.Names;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalakobana.Persistence.Configurations
{
    internal class LastNameConfiguration : BaseConfiguration<FirstName>
    {
        public override void Configure(EntityTypeBuilder<FirstName> builder)
        {
            builder.HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.Name).IsRequired().IsUnicode(false);

        }
    }
}

