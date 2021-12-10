using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class MessageConfiguration : BaseEntityConfiguration<Message>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.RoomId).IsRequired();
            builder.HasOne(x => x.Room)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.RoomId);


            builder.HasOne(x => x.ReplyTo)
                .WithOne()
                .HasForeignKey<Message>(x => x.ReplyToId);
        }
    }
}
