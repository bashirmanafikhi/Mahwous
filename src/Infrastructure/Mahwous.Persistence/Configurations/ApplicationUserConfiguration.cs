using Mahwous.Core.Entities;
using Mahwous.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.Categories)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Posts)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.MobileApps)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ImageStatuses)
                .WithOne()
                .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.VideoStatuses)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.QuoteStatuses)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ChatRooms)
                .WithOne()
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
