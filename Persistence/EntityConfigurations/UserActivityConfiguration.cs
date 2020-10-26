using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.HasKey(ua => new {ua.AppUserId, ua.ActivityId});

            builder
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.UserActivities)
                .HasForeignKey(ua => ua.AppUserId);

            builder
                .HasOne(ua => ua.Activity)
                .WithMany(a => a.UserActivities)
                .HasForeignKey(ua => ua.ActivityId);

            builder.HasData(
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId1,
                    AppUserId = SeedIds.UserId2,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Feb 1, 2020"),
                },
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId1,
                    AppUserId = SeedIds.UserId3,
                    IsHost = false,
                    DateJoined = DateTime.Parse("Feb 1, 2020"),
                },
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId2,
                    AppUserId = SeedIds.UserId1,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Mar 1, 2020"),
                },
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId3,
                    AppUserId = SeedIds.UserId3,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Oct 1, 2020"),
                },
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId4,
                    AppUserId = SeedIds.UserId3,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Oct 1, 2020"),
                },
                new UserActivity
                {
                    ActivityId = SeedIds.ActivityId4,
                    AppUserId = SeedIds.UserId1,
                    IsHost = false,
                    DateJoined = DateTime.Parse("Oct 1, 2020"),
                }
            );
        }
    }
}
