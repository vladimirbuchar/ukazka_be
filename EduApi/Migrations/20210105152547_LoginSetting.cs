using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class LoginSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FacebookLogin",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GoogleLogin",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PasswordReset",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Registration",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLogin",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "GoogleLogin",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "PasswordReset",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "Registration",
                table: "Edu_OrganizationSetting");
        }
    }
}
