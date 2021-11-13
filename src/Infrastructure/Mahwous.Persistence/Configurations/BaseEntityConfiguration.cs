using Mahwous.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //Base Configurations
            builder.HasKey(x => x.Id);

            ConfigureOtherProperties(builder);
        }


        // Template Method Design Pattern
        public abstract void ConfigureOtherProperties(EntityTypeBuilder<TEntity> builder);
    }
}
