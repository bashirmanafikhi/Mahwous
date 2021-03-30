using MahwousWeb.Server.Models;
using MahwousWeb.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MahwousWeb.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusCategories>().HasKey(x => new { x.StatusId, x.CategoryId });
            modelBuilder.Entity<NotificationApps>().HasKey(x => new { x.NotificationId, x.AppId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusCategories> StatusCategories { get; set; }
        public DbSet<ImageStatus> ImageStatuses { get; set; }
        public DbSet<VideoStatus> VideoStatuses { get; set; }
        public DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationApps> NotificationApps { get; set; }
    }
}
