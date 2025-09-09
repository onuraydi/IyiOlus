using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editNotificationModelMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrefferedDayOfWeek",
                table: "Notifications",
                newName: "PreferredDayOfWeek");

            migrationBuilder.RenameColumn(
                name: "PreferedTime",
                table: "Notifications",
                newName: "PreferredTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTime",
                table: "Notifications",
                newName: "PreferedTime");

            migrationBuilder.RenameColumn(
                name: "PreferredDayOfWeek",
                table: "Notifications",
                newName: "PrefferedDayOfWeek");
        }
    }
}
