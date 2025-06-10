using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAccountInfos_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAccountInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountInfoId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAccountInfoId",
                table: "Users",
                column: "UserAccountInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAccountInfos_UserAccountInfoId",
                table: "Users",
                column: "UserAccountInfoId",
                principalTable: "UserAccountInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAccountInfos_UserAccountInfoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserAccountInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAccountInfoId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserAccountInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAccountInfos_Id",
                table: "Users",
                column: "Id",
                principalTable: "UserAccountInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
