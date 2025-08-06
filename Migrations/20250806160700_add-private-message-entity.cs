using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriConnect.Migrations
{
    /// <inheritdoc />
    public partial class addprivatemessageentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateChat_AspNetUsers_User1Id",
                table: "PrivateChat");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateChat_AspNetUsers_User2Id",
                table: "PrivateChat");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_SenderId",
                table: "PrivateMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_PrivateChat_ChatId",
                table: "PrivateMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateMessage",
                table: "PrivateMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateChat",
                table: "PrivateChat");

            migrationBuilder.RenameTable(
                name: "PrivateMessage",
                newName: "PrivateMessages");

            migrationBuilder.RenameTable(
                name: "PrivateChat",
                newName: "PrivateChats");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessage_SenderId",
                table: "PrivateMessages",
                newName: "IX_PrivateMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessage_ChatId",
                table: "PrivateMessages",
                newName: "IX_PrivateMessages_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateChat_User2Id",
                table: "PrivateChats",
                newName: "IX_PrivateChats_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateChat_User1Id",
                table: "PrivateChats",
                newName: "IX_PrivateChats_User1Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateMessages",
                table: "PrivateMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateChats",
                table: "PrivateChats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateChats_AspNetUsers_User1Id",
                table: "PrivateChats",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateChats_AspNetUsers_User2Id",
                table: "PrivateChats",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_AspNetUsers_SenderId",
                table: "PrivateMessages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessages_PrivateChats_ChatId",
                table: "PrivateMessages",
                column: "ChatId",
                principalTable: "PrivateChats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateChats_AspNetUsers_User1Id",
                table: "PrivateChats");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateChats_AspNetUsers_User2Id",
                table: "PrivateChats");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_AspNetUsers_SenderId",
                table: "PrivateMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessages_PrivateChats_ChatId",
                table: "PrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateMessages",
                table: "PrivateMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateChats",
                table: "PrivateChats");

            migrationBuilder.RenameTable(
                name: "PrivateMessages",
                newName: "PrivateMessage");

            migrationBuilder.RenameTable(
                name: "PrivateChats",
                newName: "PrivateChat");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessages_SenderId",
                table: "PrivateMessage",
                newName: "IX_PrivateMessage_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateMessages_ChatId",
                table: "PrivateMessage",
                newName: "IX_PrivateMessage_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateChats_User2Id",
                table: "PrivateChat",
                newName: "IX_PrivateChat_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_PrivateChats_User1Id",
                table: "PrivateChat",
                newName: "IX_PrivateChat_User1Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateMessage",
                table: "PrivateMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateChat",
                table: "PrivateChat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateChat_AspNetUsers_User1Id",
                table: "PrivateChat",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateChat_AspNetUsers_User2Id",
                table: "PrivateChat",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_AspNetUsers_SenderId",
                table: "PrivateMessage",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_PrivateChat_ChatId",
                table: "PrivateMessage",
                column: "ChatId",
                principalTable: "PrivateChat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
