using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Model.Entities;

namespace Solution.Infrastructure.Database
{
    public sealed class UserLogConfiguration : IEntityTypeConfiguration<UserLogEntity>
    {
        public void Configure(EntityTypeBuilder<UserLogEntity> builder)
        {
            builder.ToTable("UsersLogs", "User");

            builder.HasKey(x => x.UserLogId);

            builder.Property(x => x.UserLogId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LogType).IsRequired();
            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(8000);
            builder.Property(x => x.DateTime).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.UsersLogs).HasForeignKey(x => x.UserId);
        }
    }
}
