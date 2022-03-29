using Mahwous.Core.Entities;
using Mahwous.Persistence.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahwous.Persistence.Configurations
{
    internal class ReportConfiguration : BaseEntityConfiguration<Report>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<Report> builder)
        {
            builder.Property(x => x.ViolatorId).IsRequired();

            builder.HasOne(x => x.User as ApplicationUser)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Violator as ApplicationUser)
                .WithMany(x => x.ViolationReports)
                .HasForeignKey(x => x.ViolatorId);

        }
    }
}
