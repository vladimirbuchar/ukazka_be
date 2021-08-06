using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CultureAddContetCultureRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsContentCulture",
                table: "Cb_Culture");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnvironmentCulture",
                table: "Cb_Culture",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnvironmentCulture",
                table: "Cb_Culture");

            migrationBuilder.AddColumn<bool>(
                name: "IsContentCulture",
                table: "Cb_Culture",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
