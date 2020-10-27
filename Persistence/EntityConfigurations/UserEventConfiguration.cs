using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.HasKey(ua => new {ua.AppUserId, ActivityId = ua.EventId});

            builder
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(ua => ua.AppUserId);

            builder
                .HasOne(ua => ua.Event)
                .WithMany(a => a.UserEvents)
                .HasForeignKey(ua => ua.EventId);

            builder.HasData(
                new UserEvent
                {
                    EventId = SeedIds.ActivityId1,
                    AppUserId = SeedIds.UserId2,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Feb 1, 2020")
                },
                new UserEvent
                {
                    EventId = SeedIds.ActivityId1,
                    AppUserId = SeedIds.UserId3,
                    IsHost = false,
                    DateJoined = DateTime.Parse("Feb 1, 2020")
                },
                new UserEvent
                {
                    EventId = SeedIds.ActivityId2,
                    AppUserId = SeedIds.UserId1,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Mar 1, 2020")
                },
                new UserEvent
                {
                    EventId = SeedIds.ActivityId3,
                    AppUserId = SeedIds.UserId3,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Oct 1, 2020")
                },
                new UserEvent
                {
                    EventId = SeedIds.ActivityId4,
                    AppUserId = SeedIds.UserId3,
                    IsHost = true,
                    DateJoined = DateTime.Parse("Oct 1, 2020")
                },
                new UserEvent
                {
                    EventId = SeedIds.ActivityId4,
                    AppUserId = SeedIds.UserId1,
                    IsHost = false,
                    DateJoined = DateTime.Parse("Oct 1, 2020")
                }
            );
        }
    }
}
