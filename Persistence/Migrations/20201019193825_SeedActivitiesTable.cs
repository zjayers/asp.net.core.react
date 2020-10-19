using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("dc3b6df6-0118-4e44-b6f5-82f7645c74f7"), "drinks", "London", new DateTime(2020, 8, 19, 14, 38, 25, 584, DateTimeKind.Local).AddTicks(3010), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("411e04c4-2ba1-40d8-be01-a656319634e7"), "culture", "Paris", new DateTime(2020, 9, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2190), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("1525ffc8-c893-441b-9f08-a7760b061698"), "culture", "London", new DateTime(2020, 11, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2270), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("6e7763f4-f677-4cde-aa8e-4a6a8c9c62a1"), "music", "London", new DateTime(2020, 12, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2270), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("c3481f1a-f70b-438c-a78f-45a4da2d5248"), "drinks", "London", new DateTime(2021, 1, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2280), "Activity 3 months in future", "Future Activity 3", "Another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("144645da-c088-4282-80f2-184c5070bd2f"), "drinks", "London", new DateTime(2021, 2, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2290), "Activity 4 months in future", "Future Activity 4", "Yet another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("bc4d1f45-d670-4682-ae42-63055e5d50b9"), "drinks", "London", new DateTime(2021, 3, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2290), "Activity 5 months in future", "Future Activity 5", "Just another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("deb2e4b4-9eea-4525-823a-9e82080c97ce"), "music", "London", new DateTime(2021, 4, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2300), "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("9f0625c6-f7c3-4b81-a06c-f0998d549cde"), "travel", "London", new DateTime(2021, 5, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2300), "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("a8b5b714-6cee-4189-ac2b-c3b7c02f6c9e"), "film", "London", new DateTime(2021, 6, 19, 14, 38, 25, 597, DateTimeKind.Local).AddTicks(2310), "Activity 8 months in future", "Future Activity 8", "Cinema" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("144645da-c088-4282-80f2-184c5070bd2f"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("1525ffc8-c893-441b-9f08-a7760b061698"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("411e04c4-2ba1-40d8-be01-a656319634e7"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("6e7763f4-f677-4cde-aa8e-4a6a8c9c62a1"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("9f0625c6-f7c3-4b81-a06c-f0998d549cde"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a8b5b714-6cee-4189-ac2b-c3b7c02f6c9e"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("bc4d1f45-d670-4682-ae42-63055e5d50b9"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c3481f1a-f70b-438c-a78f-45a4da2d5248"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("dc3b6df6-0118-4e44-b6f5-82f7645c74f7"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("deb2e4b4-9eea-4525-823a-9e82080c97ce"));
        }
    }
}
