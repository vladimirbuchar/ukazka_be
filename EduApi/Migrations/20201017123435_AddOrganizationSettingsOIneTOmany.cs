using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddOrganizationSettingsOIneTOmany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_OrganizationSetting_Edu_Organization_OrganizationId",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropIndex(
                name: "IX_Edu_OrganizationSetting_OrganizationId",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Edu_OrganizationSetting");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationSettingId",
                table: "Edu_Organization",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Organization_OrganizationSettingId",
                table: "Edu_Organization",
                column: "OrganizationSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Organization_Edu_OrganizationSetting_OrganizationSettingId",
                table: "Edu_Organization",
                column: "OrganizationSettingId",
                principalTable: "Edu_OrganizationSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Organization_Edu_OrganizationSetting_OrganizationSettingId",
                table: "Edu_Organization");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Organization_OrganizationSettingId",
                table: "Edu_Organization");

            migrationBuilder.DropColumn(
                name: "OrganizationSettingId",
                table: "Edu_Organization");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_OrganizationSetting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationSetting_OrganizationId",
                table: "Edu_OrganizationSetting",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_OrganizationSetting_Edu_Organization_OrganizationId",
                table: "Edu_OrganizationSetting",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
