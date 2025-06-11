using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserProfileUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Evaluations",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evaluations",
                table: "UserProfiles");
        }
    }
}
