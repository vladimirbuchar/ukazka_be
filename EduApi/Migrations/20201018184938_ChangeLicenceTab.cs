using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ChangeLicenceTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseChange",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LicenseOldId",
                table: "Edu_OrganizationSetting",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationSetting_LicenseOldId",
                table: "Edu_OrganizationSetting",
                column: "LicenseOldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                table: "Edu_OrganizationSetting",
                column: "LicenseOldId",
                principalTable: "Cb_License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_OrganizationSetting_Cb_License_LicenseOldId",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_Edu_OrganizationSetting_LicenseOldId",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "LicenseChange",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "LicenseOldId",
                table: "Edu_OrganizationSetting");
        }
    }
}
