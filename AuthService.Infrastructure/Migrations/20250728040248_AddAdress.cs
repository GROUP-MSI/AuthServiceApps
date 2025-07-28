using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "DeletedUserId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "Tokens",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ci",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "UserInfos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tokens",
                newName: "UpdatedUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Tokens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedUserId",
                table: "Tokens",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
