using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class updateduserconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "CreatedAt", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 646974038, new DateTimeOffset(new DateTime(2025, 5, 3, 21, 34, 21, 485, DateTimeKind.Unspecified).AddTicks(3990), new TimeSpan(0, 2, 0, 0, 0)), "Nduvho", "Maguwada" },
                    { 2, 728898987, new DateTimeOffset(new DateTime(2025, 5, 3, 21, 34, 21, 494, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 2, 0, 0, 0)), "Themba", "Cele" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
