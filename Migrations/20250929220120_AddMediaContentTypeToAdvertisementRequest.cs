using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaContentTypeToAdvertisementRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoMimeType",
                table: "AdvertisementRequests",
                newName: "VideoContentType");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "AdvertisementRequests",
                newName: "ImageContentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoContentType",
                table: "AdvertisementRequests",
                newName: "VideoMimeType");

            migrationBuilder.RenameColumn(
                name: "ImageContentType",
                table: "AdvertisementRequests",
                newName: "ImageMimeType");
        }
    }
}
