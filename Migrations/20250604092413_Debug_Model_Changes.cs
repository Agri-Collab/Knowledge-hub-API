using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class Debug_Model_Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "44c96145-97a1-4a7b-83c0-54aa555c3b68");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContactNo", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "72e12b07-bdf6-460e-a777-32b228f89c22", 987654210, "testuser@example.com", true, false, null, "Test", "TESTUSER@EXAMPLE.COM", "TESTUSER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDLQ4y9K6Z3CGg8bivta7fyW1NNiOa5eTKGfsQSZkva8fmxqxLGzL2t6xxCEL2Yw3Q==", null, false, "f1e2d3c4-b5a6-9876-5432-10fedcba9876", "User", false, "testuser@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1e12b07a-bdf6-460e-a777-32b228f89c22");
        }
    }
}
