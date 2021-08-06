using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSettingSmtp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmtpServerPassword",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpServerPort",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpServerUrl",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpServerUserName",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseCustomSmtpServer",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmtpServerPassword",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "SmtpServerPort",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "SmtpServerUrl",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "SmtpServerUserName",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "UseCustomSmtpServer",
                table: "Edu_OrganizationSetting");
        }
    }
}
