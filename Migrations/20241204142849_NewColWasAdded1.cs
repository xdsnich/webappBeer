using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppbotbeer.Migrations
{
    /// <inheritdoc />
    public partial class NewColWasAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelegramId",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "AuthDate",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TelegramId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
