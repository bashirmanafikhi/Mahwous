using MahwousWeb.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MahwousWeb.Shared.Models;

namespace MahwousWeb.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusCategories>().HasKey(x => new { x.StatusId, x.CategoryId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusCategories> StatusCategories { get; set; }
        public DbSet<ImageStatus> ImageStatuses { get; set; }
        public DbSet<VideoStatus> VideoStatuses { get; set; }
        public DbSet<QuoteStatus> QuoteStatuses { get; set; }

        public DbSet<App> Apps { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }


    }
}
