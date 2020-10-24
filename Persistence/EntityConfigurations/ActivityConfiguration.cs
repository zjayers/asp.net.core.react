using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new Activity
                {
                    Id = new Guid("C5D60467-2992-4878-A575-076C8B6CE32B"),
                    Title = "Past Activity 1",
                    Date = DateTime.Parse("Jan 1, 2020"),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                },
                new Activity
                {
                    Id = new Guid("7A78F37F-A57C-49AE-A9A7-B6CB8A7303CC"),
                    Title = "Past Activity 2",
                    Date = DateTime.Parse("Feb 1, 2020"),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre",
                },
                new Activity
                {
                    Id = new Guid("10C98CBE-4B04-4391-AB60-C245F226894D"),
                    Title = "Future Activity 1",
                    Date = DateTime.Parse("Mar 1, 2020"),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum",
                },
                new Activity
                {
                    Id = new Guid("43A767B8-7C7D-45AE-AD1A-DDA85F671A45"),
                    Title = "Future Activity 2",
                    Date = DateTime.Parse("Apr 1, 2020"),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "O2 Arena",
                },
                new Activity
                {
                    Id = new Guid("CBB0C7E1-7CA2-41F4-B8C9-71EC0811BFCF"),
                    Title = "Future Activity 3",
                    Date = DateTime.Parse("May 1, 2020"),
                    Description = "Activity 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Another pub",
                },
                new Activity
                {
                    Id = new Guid("94BC256B-25CD-4D0F-A372-FD16456A29B3"),
                    Title = "Future Activity 4",
                    Date = DateTime.Parse("Jun 1, 2020"),
                    Description = "Activity 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Yet another pub",
                },
                new Activity
                {
                    Id = new Guid("D408D2CE-8640-4A63-9795-CD843DD093FB"),
                    Title = "Future Activity 5",
                    Date = DateTime.Parse("Jul 1, 2020"),
                    Description = "Activity 5 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "Just another pub",
                },
                new Activity
                {
                    Id = new Guid("A2BE1F21-5AF9-424F-B6FA-49B18AF1BE72"),
                    Title = "Future Activity 6",
                    Date = DateTime.Parse("Aug 1, 2020"),
                    Description = "Activity 6 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "Roundhouse Camden",
                },
                new Activity
                {
                    Id = new Guid("6220481F-AFAB-40ED-BB81-0EB4B6DF9F5F"),
                    Title = "Future Activity 7",
                    Date = DateTime.Parse("Sep 1, 2020"),
                    Description = "Activity 2 months ago",
                    Category = "travel",
                    City = "London",
                    Venue = "Somewhere on the Thames",
                },
                new Activity
                {
                    Id = new Guid("FFF48D9B-B520-4C3F-A71E-4F4FE9CB2DDD"),
                    Title = "Future Activity 8",
                    Date = DateTime.Parse("Oct 1, 2020"),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "London",
                    Venue = "Cinema",
                });
        }
    }
}
