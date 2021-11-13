using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Category> builder)
        {

        }
    }
}
