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
            const string descriptionPlaceholder = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            builder.HasData(
                new Event
                {
                    Id = SeedIds.ActivityId1,
                    Title = "Future Activity 1",
                    Date = DateTime.Parse("Jan 1, 2021"),
                    Description = descriptionPlaceholder,
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub"
                },
                new Event
                {
                    Id = SeedIds.ActivityId2,
                    Title = "Future Activity 2",
                    Date = DateTime.Parse("Feb 1, 2021"),
                    Description = descriptionPlaceholder,
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre"
                },
                new Event
                {
                    Id = SeedIds.ActivityId3,
                    Title = "Future Activity 3",
                    Date = DateTime.Parse("Mar 1, 2021"),
                    Description = descriptionPlaceholder,
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum"
                },
                new Event
                {
                    Id = SeedIds.ActivityId4,
                    Title = "Future Activity 4",
                    Date = DateTime.Parse("Apr 1, 2021"),
                    Description = descriptionPlaceholder,
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena"
                });
        }
    }
}
