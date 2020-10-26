using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    Id = SeedIds.ActivityId1,
                    Title = "Past Activity 1",
                    Date = DateTime.Parse("Jan 1, 2020"),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub"
                },
                new Event
                {
                    Id = SeedIds.ActivityId2,
                    Title = "Past Activity 2",
                    Date = DateTime.Parse("Feb 1, 2020"),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre"
                },
                new Event
                {
                    Id = SeedIds.ActivityId3,
                    Title = "Future Activity 1",
                    Date = DateTime.Parse("Mar 1, 2020"),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum"
                },
                new Event
                {
                    Id = SeedIds.ActivityId4,
                    Title = "Future Activity 2",
                    Date = DateTime.Parse("Apr 1, 2020"),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena"
                });
        }
    }
}
