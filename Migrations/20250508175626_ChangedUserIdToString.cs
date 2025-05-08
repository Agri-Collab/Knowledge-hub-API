using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "Name", "Surname" },
                values: new object[,]
                {
                    { "a7f3b82e-2d58-4d59-a4a7-3c5d6212c520", 728898987, "Themba", "Cele" },
                    { "a7f3b82e-2d58-4d59-a4a7-3c5d6212c720", 646974038, "Nduvho", "Maguwada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a7f3b82e-2d58-4d59-a4a7-3c5d6212c520");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a7f3b82e-2d58-4d59-a4a7-3c5d6212c720");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNo", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 646974038, "Nduvho", "Maguwada" },
                    { 2, 728898987, "Themba", "Cele" }
                });
        }
    }
}
