using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MahwousWeb.Persistent.Configurations
{
    internal class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Category> builder)
        {

        }
    }
}
