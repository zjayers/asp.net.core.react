using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateGuidsToStaticInActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("03889a26-54c8-4a3f-9040-f81f6bb2b86f"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("06b4e450-2aa7-40a1-a753-8aa65bda0cd7"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("1adbe36e-c602-4f70-859d-34623f2ec450"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("1d0a8e09-8edb-461d-819b-a0e27953e992"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("525bc483-8d2e-4b9c-b5b2-4c8873d8d265"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("76f204ab-9f2d-418e-adb7-90c9e641b8d5"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("8fb1e2e1-888a-42ac-a3aa-ffe1a90c1896"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("ae3a809c-61a0-4332-8e6c-5be1f7d9595e"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("ce0086c0-e93f-4ae2-9fa4-c1b72a02dc90"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("e5ba60cf-9fd0-4cf0-b5bc-4012f5f5e57e"));

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), "drinks", "London",
                    new DateTime(2020, 8, 24, 10, 14, 36, 360, DateTimeKind.Local).AddTicks(4520),
                    "Activity 2 months ago", "Past Activity 1", "Pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("7a78f37f-a57c-49ae-a9a7-b6cb8a7303cc"), "culture", "Paris",
                    new DateTime(2020, 9, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(250),
                    "Activity 1 month ago", "Past Activity 2", "Louvre"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("10c98cbe-4b04-4391-ab60-c245f226894d"), "culture", "London",
                    new DateTime(2020, 11, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(310),
                    "Activity 1 month in future", "Future Activity 1", "Natural History Museum"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("43a767b8-7c7d-45ae-ad1a-dda85f671a45"), "music", "London",
                    new DateTime(2020, 12, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(320),
                    "Activity 2 months in future", "Future Activity 2", "O2 Arena"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"), "drinks", "London",
                    new DateTime(2021, 1, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(330),
                    "Activity 3 months in future", "Future Activity 3", "Another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("94bc256b-25cd-4d0f-a372-fd16456a29b3"), "drinks", "London",
                    new DateTime(2021, 2, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(330),
                    "Activity 4 months in future", "Future Activity 4", "Yet another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"), "drinks", "London",
                    new DateTime(2021, 3, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340),
                    "Activity 5 months in future", "Future Activity 5", "Just another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("a2be1f21-5af9-424f-b6fa-49b18af1be72"), "music", "London",
                    new DateTime(2021, 4, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340),
                    "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("6220481f-afab-40ed-bb81-0eb4b6df9f5f"), "travel", "London",
                    new DateTime(2021, 5, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340),
                    "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"), "film", "London",
                    new DateTime(2021, 6, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(390),
                    "Activity 8 months in future", "Future Activity 8", "Cinema"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("10c98cbe-4b04-4391-ab60-c245f226894d"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("43a767b8-7c7d-45ae-ad1a-dda85f671a45"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("6220481f-afab-40ed-bb81-0eb4b6df9f5f"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("7a78f37f-a57c-49ae-a9a7-b6cb8a7303cc"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("94bc256b-25cd-4d0f-a372-fd16456a29b3"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("a2be1f21-5af9-424f-b6fa-49b18af1be72"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"));

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("06b4e450-2aa7-40a1-a753-8aa65bda0cd7"), "drinks", "London",
                    new DateTime(2020, 8, 24, 9, 35, 13, 643, DateTimeKind.Local).AddTicks(6570),
                    "Activity 2 months ago", "Past Activity 1", "Pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("e5ba60cf-9fd0-4cf0-b5bc-4012f5f5e57e"), "culture", "Paris",
                    new DateTime(2020, 9, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(550), "Activity 1 month ago",
                    "Past Activity 2", "Louvre"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("8fb1e2e1-888a-42ac-a3aa-ffe1a90c1896"), "culture", "London",
                    new DateTime(2020, 11, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(730),
                    "Activity 1 month in future", "Future Activity 1", "Natural History Museum"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("ae3a809c-61a0-4332-8e6c-5be1f7d9595e"), "music", "London",
                    new DateTime(2020, 12, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(740),
                    "Activity 2 months in future", "Future Activity 2", "O2 Arena"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("1d0a8e09-8edb-461d-819b-a0e27953e992"), "drinks", "London",
                    new DateTime(2021, 1, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(740),
                    "Activity 3 months in future", "Future Activity 3", "Another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("03889a26-54c8-4a3f-9040-f81f6bb2b86f"), "drinks", "London",
                    new DateTime(2021, 2, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(750),
                    "Activity 4 months in future", "Future Activity 4", "Yet another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("1adbe36e-c602-4f70-859d-34623f2ec450"), "drinks", "London",
                    new DateTime(2021, 3, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(760),
                    "Activity 5 months in future", "Future Activity 5", "Just another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("ce0086c0-e93f-4ae2-9fa4-c1b72a02dc90"), "music", "London",
                    new DateTime(2021, 4, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(760),
                    "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("525bc483-8d2e-4b9c-b5b2-4c8873d8d265"), "travel", "London",
                    new DateTime(2021, 5, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(770),
                    "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("76f204ab-9f2d-418e-adb7-90c9e641b8d5"), "film", "London",
                    new DateTime(2021, 6, 24, 9, 35, 13, 654, DateTimeKind.Local).AddTicks(770),
                    "Activity 8 months in future", "Future Activity 8", "Cinema"
                });
        }
    }
}