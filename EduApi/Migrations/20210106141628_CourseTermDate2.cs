using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseTermDate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTerm_Edu_CourseTermDate_CourseTermDateId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTerm_CourseTermDateId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "CourseTermDateId",
                table: "Edu_CourseTerm");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_CourseTermId",
                table: "Edu_CourseTermDate",
                column: "CourseTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Edu_CourseTerm_CourseTermId",
                table: "Edu_CourseTermDate",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Edu_CourseTerm_CourseTermId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_CourseTermId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "CourseTermId",
                table: "Edu_CourseTermDate");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermDateId",
                table: "Edu_CourseTerm",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseTermDateId",
                table: "Edu_CourseTerm",
                column: "CourseTermDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Edu_CourseTermDate_CourseTermDateId",
                table: "Edu_CourseTerm",
                column: "CourseTermDateId",
                principalTable: "Edu_CourseTermDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
