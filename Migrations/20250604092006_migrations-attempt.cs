using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class migrationsattempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e12b07a-bdf6-460e-a777-32b228f89c22", "AQAAAAIAAYagAAAAEHqv6PdMX+oZQXdq8J6GnVUx6edV+XXjMMn37jLmMaX4EgI7opxS667OMwonfQxMOg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ccefe9d-e1fa-4251-9464-b3326b730867", "AQAAAAIAAYagAAAAEG3123C0v9Yv4K9w==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ContactNo", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "8b1a1718-12be-4842-9dd7-129e18d91715", 987654210, "testuser@example.com", true, false, null, "Test", "TESTUSER@EXAMPLE.COM", "TESTUSER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFwC0x321321w==", null, false, "f1e2d3c4-b5a6-9876-5432-10fedcba9876", "User", false, "testuser@example.com" });
        }
    }
}
