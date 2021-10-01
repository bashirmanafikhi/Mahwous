using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahwousWeb.Persistent.Configurations
{
    internal class NotificationConfiguration : BaseEntityConfiguration<Notification>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Notification> builder)
        {

        }
    }
}
