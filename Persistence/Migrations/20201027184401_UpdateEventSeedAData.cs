using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateEventSeedAData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Future Activity 3" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("94502f82-d435-40ea-992e-5746385c545c"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Future Activity 2" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Future Activity 1" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Future Activity 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Activity 1 month in future", "Future Activity 1" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("94502f82-d435-40ea-992e-5746385c545c"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Activity 1 month ago", "Past Activity 2" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Activity 2 months ago", "Past Activity 1" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Activity 2 months in future", "Future Activity 2" });
        }
    }
}
