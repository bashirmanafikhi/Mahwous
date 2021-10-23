﻿using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class NotificationConfiguration : BaseEntityConfiguration<MobileNotification>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<MobileNotification> builder)
        {

        }
    }
}
