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
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Posts)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.MobileApps)
                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ChatRooms)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ExternalLinks)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.MobileNotifications)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Statuses)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Messages)
                                .WithOne(x => x.User as ApplicationUser)
                .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
