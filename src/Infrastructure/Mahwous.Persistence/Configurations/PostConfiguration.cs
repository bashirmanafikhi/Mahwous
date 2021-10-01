using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahwousWeb.Persistent.Configurations
{
    internal class PostConfiguration : BaseEntityConfiguration<Post>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
