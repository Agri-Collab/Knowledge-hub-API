using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdvertisementRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AdvertisementRequests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "AdvertisementRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoMimeType",
                table: "AdvertisementRequests",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "AdvertisementRequests");

            migrationBuilder.DropColumn(
                name: "VideoMimeType",
                table: "AdvertisementRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AdvertisementRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
