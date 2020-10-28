using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ReSeedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7B01DF1A-2D77-4872-B383-7C5683035FBD",
                column: "EmailConfirmed",
                value: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED",
                column: "EmailConfirmed",
                value: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F169161F-C669-4CF9-8A33-662FFFBCEB7B",
                column: "EmailConfirmed",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7B01DF1A-2D77-4872-B383-7C5683035FBD",
                column: "EmailConfirmed",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D8C62AEE-ADE7-4A9F-8A26-50C20ED5F1ED",
                column: "EmailConfirmed",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "F169161F-C669-4CF9-8A33-662FFFBCEB7B",
                column: "EmailConfirmed",
                value: false);
        }
    }
}
