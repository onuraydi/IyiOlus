using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IyiOlus.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migUpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1️⃣ Kolon tipini string yap (nvarchar(max)), nullable bırak
            migrationBuilder.AlterColumn<string>(
                name: "OldProfile",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true, // önce nullable yap
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            // 2️⃣ Eski NULL veya int değerleri JSON '[]' olarak güncelle
            migrationBuilder.Sql(@"
            UPDATE [UserProfiles] 
            SET [OldProfile] = '[]'
            WHERE OldProfile IS NULL OR TRY_CAST(OldProfile AS nvarchar(max)) IS NULL
        ");

            // 3️⃣ Kolonu NOT NULL ve default value ile tamamla
            migrationBuilder.AlterColumn<string>(
                name: "OldProfile",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OldProfile",
                table: "UserProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
