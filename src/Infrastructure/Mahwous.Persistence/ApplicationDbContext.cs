using Mahwous.Core.Entities;
using MahwousWeb.Persistent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MahwousWeb.Persistent
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser/*, IdentityRole ,Guid*/>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // this will apply the configurations for entire project instead of apply them separately
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        // DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ImageStatus> ImageStatuses { get; set; }
        public DbSet<VideoStatus> VideoStatuses { get; set; }
        public DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<MobileApp> MobileApps { get; set; }
        public DbSet<MobileNotification> MobileNotifications { get; set; }
    }
}
