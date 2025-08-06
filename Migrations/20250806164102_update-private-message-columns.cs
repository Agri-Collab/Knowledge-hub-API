using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class updateprivatemessagecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<DateTime>(
        name: "SentAt",
        table: "PrivateMessages",
        type: "timestamp with time zone",
        nullable: false,
        defaultValue: DateTime.UtcNow);

    migrationBuilder.AddColumn<bool>(
        name: "IsRead",
        table: "PrivateMessages",
        type: "boolean",
        nullable: false,
        defaultValue: false);
}


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "SentAt",
        table: "PrivateMessages");

    migrationBuilder.DropColumn(
        name: "IsRead",
        table: "PrivateMessages");
}

    }
}
