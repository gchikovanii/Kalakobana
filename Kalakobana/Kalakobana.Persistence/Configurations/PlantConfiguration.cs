using Kalakobana.Domain.Names;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Kalakobana.Persistence.Configurations
{
    internal class PlantConfiguration : BaseConfiguration<FirstName>
    {
        public override void Configure(EntityTypeBuilder<FirstName> builder)
        {
            builder.HasIndex(i => i.Name).IsUnique();
            builder.Property(i => i.Name).IsRequired().IsUnicode(false);

        }
    }
}
