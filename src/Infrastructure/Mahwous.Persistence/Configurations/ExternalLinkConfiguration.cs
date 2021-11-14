using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class ExternalLinkConfiguration : BaseEntityConfiguration<ExternalLink>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<ExternalLink> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Url).IsRequired();
        }
    }
}
