using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdatesAttendeeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"));

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "233683EE-CD2D-4B0D-97CD-34715E6D5BDF");

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "DEB85499-584C-49C1-8DC4-765838874650");

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "EC50E466-AE94-4D0A-BAAD-831A41191223");

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("94502f82-d435-40ea-992e-5746385c545c"), "culture", "Paris",
                    new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month ago",
                    "Past Activity 2", "Louvre"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"), "culture", "London",
                    new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month in future",
                    "Future Activity 1", "Natural History Museum"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), "music", "London",
                    new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months in future",
                    "Future Activity 2", "O2 Arena"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "7B01DF1A-2D77-4872-B383-7C5683035FBD", 0, "5c1cbe50-290a-464b-b32d-60981bea1877", "Bob",
                    "bob@test.com", false, false, null, "BOB@TEST.COM", "BOB",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "92657c22-f297-41da-984a-8deb392f5540", false, "bob"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED", 0, "c01f9e4a-5935-43aa-a137-1cf23c8c499e", "Tom",
                    "tom@test.com", false, false, null, "TOM@TEST.COM", "TOM",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "b88d0d77-d0c7-41b1-adf0-fa43d13028db", false, "tom"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "F169161F-C669-4CF9-8A33-662FFFBCEB7B", 0, "1abc3ae0-c563-4af0-aaee-bb7d6c1a0258", "Jane",
                    "jane@test.com", false, false, null, "JANE@TEST.COM", "JANE",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "87f7b445-3fa1-497f-924c-39b0f2370947", false, "jane"
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("94502f82-d435-40ea-992e-5746385c545c"),
                    new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                    new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                    new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                    new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"),
                    new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true
                });

            migrationBuilder.InsertData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId", "DateJoined", "IsHost"},
                new object[]
                {
                    "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                    new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("94502f82-d435-40ea-992e-5746385c545c")});

            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306")});

            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b")});

            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1")});

            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b")});

            migrationBuilder.DeleteData(
                "UserActivities",
                new[] {"AppUserId", "ActivityId"},
                new object[]
                    {"F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306")});

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("94502f82-d435-40ea-992e-5746385c545c"));

            migrationBuilder.DeleteData(
                "Activities",
                "Id",
                new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"));

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "7B01DF1A-2D77-4872-B383-7C5683035FBD");

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED");

            migrationBuilder.DeleteData(
                "AspNetUsers",
                "Id",
                "F169161F-C669-4CF9-8A33-662FFFBCEB7B");

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("7a78f37f-a57c-49ae-a9a7-b6cb8a7303cc"), "culture", "Paris",
                    new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month ago",
                    "Past Activity 2", "Louvre"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("10c98cbe-4b04-4391-ab60-c245f226894d"), "culture", "London",
                    new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month in future",
                    "Future Activity 1", "Natural History Museum"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("43a767b8-7c7d-45ae-ad1a-dda85f671a45"), "music", "London",
                    new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months in future",
                    "Future Activity 2", "O2 Arena"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"), "drinks", "London",
                    new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 3 months in future",
                    "Future Activity 3", "Another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("94bc256b-25cd-4d0f-a372-fd16456a29b3"), "drinks", "London",
                    new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 4 months in future",
                    "Future Activity 4", "Yet another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"), "drinks", "London",
                    new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 5 months in future",
                    "Future Activity 5", "Just another pub"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("a2be1f21-5af9-424f-b6fa-49b18af1be72"), "music", "London",
                    new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 6 months in future",
                    "Future Activity 6", "Roundhouse Camden"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("6220481f-afab-40ed-bb81-0eb4b6df9f5f"), "travel", "London",
                    new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months ago",
                    "Future Activity 7", "Somewhere on the Thames"
                });

            migrationBuilder.InsertData(
                "Activities",
                new[] {"Id", "Category", "City", "Date", "Description", "Title", "Venue"},
                new object[]
                {
                    new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"), "film", "London",
                    new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 8 months in future",
                    "Future Activity 8", "Cinema"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "233683EE-CD2D-4B0D-97CD-34715E6D5BDF", 0, "5c1cbe50-290a-464b-b32d-60981bea1877", "Bob",
                    "bob@test.com", false, false, null, "BOB@TEST.COM", "BOB",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "92657c22-f297-41da-984a-8deb392f5540", false, "bob"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "EC50E466-AE94-4D0A-BAAD-831A41191223", 0, "c01f9e4a-5935-43aa-a137-1cf23c8c499e", "Tom",
                    "tom@test.com", false, false, null, "TOM@TEST.COM", "TOM",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "b88d0d77-d0c7-41b1-adf0-fa43d13028db", false, "tom"
                });

            migrationBuilder.InsertData(
                "AspNetUsers",
                new[]
                {
                    "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed",
                    "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash",
                    "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
                },
                new object[]
                {
                    "DEB85499-584C-49C1-8DC4-765838874650", 0, "1abc3ae0-c563-4af0-aaee-bb7d6c1a0258", "Jane",
                    "jane@test.com", false, false, null, "JANE@TEST.COM", "JANE",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==", null, false,
                    "87f7b445-3fa1-497f-924c-39b0f2370947", false, "jane"
                });
        }
    }
}
