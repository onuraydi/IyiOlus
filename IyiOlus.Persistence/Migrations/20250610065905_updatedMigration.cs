using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAccountInfos_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_ProfileTestDate_UserProfileId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UserAccountInfoId",
                table: "UserAccountInfos");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ProfileTypeId",
                table: "ProfileTypes");

            migrationBuilder.DropColumn(
                name: "DailyMoodId",
                table: "DailyMoods");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ProfileTestDate_Id",
                table: "UserProfiles",
                columns: new[] { "ProfileTestDate", "Id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAccountInfos_Id",
                table: "Users",
                column: "Id",
                principalTable: "UserAccountInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAccountInfos_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_ProfileTestDate_Id",
                table: "UserProfiles");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountInfoId",
                table: "UserAccountInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SettingId",
                table: "Settings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileTypeId",
                table: "ProfileTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DailyMoodId",
                table: "DailyMoods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_ProfileTestDate_UserProfileId",
                table: "UserProfiles",
                columns: new[] { "ProfileTestDate", "UserProfileId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAccountInfos_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "UserAccountInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
