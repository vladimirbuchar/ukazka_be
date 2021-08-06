using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class OrganizationSettingCompanyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ElearningUrl",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LogoId",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "ElearningUrl",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Edu_OrganizationSetting");
        }
    }
}
