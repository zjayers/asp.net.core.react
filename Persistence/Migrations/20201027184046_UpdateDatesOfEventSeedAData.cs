using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateDatesOfEventSeedAData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"),
                column: "Date",
                value: new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("94502f82-d435-40ea-992e-5746385c545c"),
                column: "Date",
                value: new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                column: "Date",
                value: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                column: "Date",
                value: new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4c81c658-272d-41ac-b406-48b85e05fcc1"),
                column: "Date",
                value: new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("94502f82-d435-40ea-992e-5746385c545c"),
                column: "Date",
                value: new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                column: "Date",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fc2f7480-4b54-4564-b737-34ccb832f306"),
                column: "Date",
                value: new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
