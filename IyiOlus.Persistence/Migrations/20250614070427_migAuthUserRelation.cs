using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migAuthUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_UserAccountInfos_UserAccountInfoId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "UserAccountInfos");

            migrationBuilder.RenameColumn(
                name: "UserAccountInfoId",
                table: "AppUsers",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_UserAccountInfoId",
                table: "AppUsers",
                newName: "IX_AppUsers_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AspNetUsers_ApplicationUserId",
                table: "AppUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AspNetUsers_ApplicationUserId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "AppUsers",
                newName: "UserAccountInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ApplicationUserId",
                table: "AppUsers",
                newName: "IX_AppUsers_UserAccountInfoId");

            migrationBuilder.CreateTable(
                name: "UserAccountInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isVerification = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountInfos_Email",
                table: "UserAccountInfos",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_UserAccountInfos_UserAccountInfoId",
                table: "AppUsers",
                column: "UserAccountInfoId",
                principalTable: "UserAccountInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
