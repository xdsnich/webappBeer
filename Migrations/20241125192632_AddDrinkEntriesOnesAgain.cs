using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppbotbeer.Migrations
{
    /// <inheritdoc />
    public partial class AddDrinkEntriesOnesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkEntry_Users_UserId",
                table: "DrinkEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkEntry",
                table: "DrinkEntry");

            migrationBuilder.RenameTable(
                name: "DrinkEntry",
                newName: "DrinkEntries");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkEntry_UserId",
                table: "DrinkEntries",
                newName: "IX_DrinkEntries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkEntries",
                table: "DrinkEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkEntries_Users_UserId",
                table: "DrinkEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkEntries_Users_UserId",
                table: "DrinkEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkEntries",
                table: "DrinkEntries");

            migrationBuilder.RenameTable(
                name: "DrinkEntries",
                newName: "DrinkEntry");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkEntries_UserId",
                table: "DrinkEntry",
                newName: "IX_DrinkEntry_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkEntry",
                table: "DrinkEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkEntry_Users_UserId",
                table: "DrinkEntry",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
