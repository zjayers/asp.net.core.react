using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateDatesToStaticInActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("10c98cbe-4b04-4391-ab60-c245f226894d"),
                column: "Date",
                value: new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("43a767b8-7c7d-45ae-ad1a-dda85f671a45"),
                column: "Date",
                value: new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("6220481f-afab-40ed-bb81-0eb4b6df9f5f"),
                column: "Date",
                value: new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7a78f37f-a57c-49ae-a9a7-b6cb8a7303cc"),
                column: "Date",
                value: new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("94bc256b-25cd-4d0f-a372-fd16456a29b3"),
                column: "Date",
                value: new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a2be1f21-5af9-424f-b6fa-49b18af1be72"),
                column: "Date",
                value: new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                column: "Date",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"),
                column: "Date",
                value: new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"),
                column: "Date",
                value: new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"),
                column: "Date",
                value: new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("10c98cbe-4b04-4391-ab60-c245f226894d"),
                column: "Date",
                value: new DateTime(2020, 11, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("43a767b8-7c7d-45ae-ad1a-dda85f671a45"),
                column: "Date",
                value: new DateTime(2020, 12, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("6220481f-afab-40ed-bb81-0eb4b6df9f5f"),
                column: "Date",
                value: new DateTime(2021, 5, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7a78f37f-a57c-49ae-a9a7-b6cb8a7303cc"),
                column: "Date",
                value: new DateTime(2020, 9, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("94bc256b-25cd-4d0f-a372-fd16456a29b3"),
                column: "Date",
                value: new DateTime(2021, 2, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a2be1f21-5af9-424f-b6fa-49b18af1be72"),
                column: "Date",
                value: new DateTime(2021, 4, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c5d60467-2992-4878-a575-076c8b6ce32b"),
                column: "Date",
                value: new DateTime(2020, 8, 24, 10, 14, 36, 360, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("cbb0c7e1-7ca2-41f4-b8c9-71ec0811bfcf"),
                column: "Date",
                value: new DateTime(2021, 1, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d408d2ce-8640-4a63-9795-cd843dd093fb"),
                column: "Date",
                value: new DateTime(2021, 3, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("fff48d9b-b520-4c3f-a71e-4f4fe9cb2ddd"),
                column: "Date",
                value: new DateTime(2021, 6, 24, 10, 14, 36, 371, DateTimeKind.Local).AddTicks(390));
        }
    }
}
