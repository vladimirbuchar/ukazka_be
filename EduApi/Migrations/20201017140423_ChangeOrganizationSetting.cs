using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeOrganizationSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Edu_OrganizationSetting");

            migrationBuilder.AddColumn<string>(
                name: "UserDefaultPassword",
                table: "Edu_OrganizationSetting",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDefaultPassword",
                table: "Edu_OrganizationSetting");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Edu_OrganizationSetting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Edu_OrganizationSetting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
