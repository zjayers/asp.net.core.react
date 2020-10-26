using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddsNormalizedUsernameAndEmailToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "233683EE-CD2D-4B0D-97CD-34715E6D5BDF",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "5c1cbe50-290a-464b-b32d-60981bea1877", "BOB@TEST.COM", "BOB",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    "92657c22-f297-41da-984a-8deb392f5540"
                });

            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "DEB85499-584C-49C1-8DC4-765838874650",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "1abc3ae0-c563-4af0-aaee-bb7d6c1a0258", "JANE@TEST.COM", "JANE",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    "87f7b445-3fa1-497f-924c-39b0f2370947"
                });

            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "EC50E466-AE94-4D0A-BAAD-831A41191223",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "c01f9e4a-5935-43aa-a137-1cf23c8c499e", "TOM@TEST.COM", "TOM",
                    "AQAAAAEAACcQAAAAEAy90BXaaDIxJm+9G2FiuKBNmjnGr4/syBRu/GTPuAZ2DbIAWNb1kl2VzC4PfBDJkA==",
                    "b88d0d77-d0c7-41b1-adf0-fa43d13028db"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "233683EE-CD2D-4B0D-97CD-34715E6D5BDF",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "77c69014-3a44-449b-b5b4-758936cbcb85", null, null,
                    "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==",
                    "dde5f73d-a0e1-4d14-b6db-6814ec765d30"
                });

            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "DEB85499-584C-49C1-8DC4-765838874650",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "d35d68be-e2ef-42b2-867a-5b7b1036830f", null, null,
                    "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==",
                    "b363faf7-e98e-4eed-968b-73f10e2df084"
                });

            migrationBuilder.UpdateData(
                "AspNetUsers",
                "Id",
                "EC50E466-AE94-4D0A-BAAD-831A41191223",
                new[] {"ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp"},
                new object[]
                {
                    "e38c631d-81a8-4a4e-a040-7e6efad6536b", null, null,
                    "AQAAAAEAACcQAAAAEJsma5sIxGvcKlL99z7XGz+Vz3d5CRQDtaowIE0DyvZgD29M5xGTpiV0V2JLT2q7ng==",
                    "9638118a-7bf2-4d0a-a314-a0835462b2c8"
                });
        }
    }
}