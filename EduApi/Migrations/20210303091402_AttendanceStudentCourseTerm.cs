using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AttendanceStudentCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermId",
                table: "Edu_AttendanceStudent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AttendanceStudent_CourseTermId",
                table: "Edu_AttendanceStudent",
                column: "CourseTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_AttendanceStudent_Edu_CourseTerm_CourseTermId",
                table: "Edu_AttendanceStudent",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_AttendanceStudent_Edu_CourseTerm_CourseTermId",
                table: "Edu_AttendanceStudent");

            migrationBuilder.DropIndex(
                name: "IX_Edu_AttendanceStudent_CourseTermId",
                table: "Edu_AttendanceStudent");

            migrationBuilder.DropColumn(
                name: "CourseTermId",
                table: "Edu_AttendanceStudent");
        }
    }
}
