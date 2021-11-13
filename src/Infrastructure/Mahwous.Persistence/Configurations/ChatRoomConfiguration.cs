using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class ChatRoomConfiguration : BaseEntityConfiguration<ChatRoom>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
