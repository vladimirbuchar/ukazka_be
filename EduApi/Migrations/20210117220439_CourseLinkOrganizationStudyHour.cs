using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseLinkOrganizationStudyHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                column: "OrganizationStudyHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId",
                table: "Edu_CourseTerm",
                column: "OrganizationStudyHourId",
                principalTable: "Edu_OrganizationStudyHour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTerm_Edu_OrganizationStudyHour_OrganizationStudyHourId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTerm_OrganizationStudyHourId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "OrganizationStudyHourId",
                table: "Edu_CourseTerm");
        }
    }
}
