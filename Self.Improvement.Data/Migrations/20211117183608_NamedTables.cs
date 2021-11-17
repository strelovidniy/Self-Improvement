using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Self.Improvement.Data.Migrations
{
    public partial class NamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chat_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_UserId",
                table: "Chats",
                newName: "IX_Chats_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_UserId",
                table: "Chats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_UserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserId",
                table: "Chat",
                newName: "IX_Chat_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chat_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
