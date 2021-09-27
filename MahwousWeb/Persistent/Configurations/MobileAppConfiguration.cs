using Mahwous.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahwousWeb.Persistent.Configurations
{
    internal class MobileAppConfiguration : IEntityTypeConfiguration<MobileApp>
    {
        public void Configure(EntityTypeBuilder<MobileApp> builder)
        {

        }
    }
}
