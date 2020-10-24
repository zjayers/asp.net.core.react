using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedUsersToAspNetUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "233683EE-CD2D-4B0D-97CD-34715E6D5BDF", 0, "77c69014-3a44-449b-b5b4-758936cbcb85", "Bob", "bob@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==", null, false, "dde5f73d-a0e1-4d14-b6db-6814ec765d30", false, "bob" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "EC50E466-AE94-4D0A-BAAD-831A41191223", 0, "e38c631d-81a8-4a4e-a040-7e6efad6536b", "Tom", "tom@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==", null, false, "9638118a-7bf2-4d0a-a314-a0835462b2c8", false, "tom" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "DEB85499-584C-49C1-8DC4-765838874650", 0, "d35d68be-e2ef-42b2-867a-5b7b1036830f", "Jane", "jane@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==", null, false, "b363faf7-e98e-4eed-968b-73f10e2df084", false, "jane" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "233683EE-CD2D-4B0D-97CD-34715E6D5BDF");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DEB85499-584C-49C1-8DC4-765838874650");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "EC50E466-AE94-4D0A-BAAD-831A41191223");
        }
    }
}
