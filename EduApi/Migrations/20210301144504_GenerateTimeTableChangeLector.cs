using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class GenerateTimeTableChangeLector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_CourseLectorId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "CourseLectorId",
                table: "Edu_CourseTermDate");

            migrationBuilder.AddColumn<Guid>(
                name: "UserInOrganizationId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_UserInOrganizationId",
                table: "Edu_CourseTermDate",
                column: "UserInOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_CourseTermDate",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_UserInOrganizationId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "UserInOrganizationId",
                table: "Edu_CourseTermDate");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLectorId",
                table: "Edu_CourseTermDate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_CourseLectorId",
                table: "Edu_CourseTermDate",
                column: "CourseLectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTermDate",
                column: "CourseLectorId",
                principalTable: "Link_CourseLector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
