using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RenamesActivityToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Venue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    DateJoined = table.Column<DateTime>(nullable: false),
                    IsHost = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.AppUserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserEvents_Events_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), "drinks", "London", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("94502f82-d435-40ea-992e-5746385c545c"), "culture", "Paris", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"), "culture", "London", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), "music", "London", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("94502f82-d435-40ea-992e-5746385c545c"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_ActivityId",
                table: "UserEvents",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Venue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsHost = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => new { x.AppUserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_UserActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserActivities_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), "drinks", "London", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("94502f82-d435-40ea-992e-5746385c545c"), "culture", "Paris", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"), "culture", "London", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), "music", "London", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("94502f82-d435-40ea-992e-5746385c545c"), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "F169161F-C669-4CF9-8A33-662FFFBCEB7B", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "UserActivities",
                columns: new[] { "AppUserId", "ActivityId", "DateJoined", "IsHost" },
                values: new object[] { "7B01DF1A-2D77-4872-B383-7C5683035FBD", new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"), new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_ActivityId",
                table: "UserActivities",
                column: "ActivityId");
        }
    }
}
