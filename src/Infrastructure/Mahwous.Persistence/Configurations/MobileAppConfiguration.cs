﻿using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class MobileAppConfiguration : BaseEntityConfiguration<MobileApp>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<MobileApp> builder)
        {

        }
    }
}
