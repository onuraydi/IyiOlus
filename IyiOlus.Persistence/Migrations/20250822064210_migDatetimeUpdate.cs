using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migDatetimeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrefferedDayOfWeek",
                table: "Notifications",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrefferedDayOfWeek",
                table: "Notifications");
        }
    }
}
