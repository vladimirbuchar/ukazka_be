using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCourseMaterialLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseLesson_Edu_Course_CourseId",
                table: "Edu_CourseLesson");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseLesson_CourseId",
                table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Edu_CourseLesson");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseMaterialId",
                table: "Edu_Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CourseMaterialId",
                table: "Edu_Course",
                column: "CourseMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_CourseMaterial_CourseMaterialId",
                table: "Edu_Course",
                column: "CourseMaterialId",
                principalTable: "Edu_CourseMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Course_Edu_CourseMaterial_CourseMaterialId",
                table: "Edu_Course");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Course_CourseMaterialId",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "CourseMaterialId",
                table: "Edu_Course");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Edu_CourseLesson",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLesson_CourseId",
                table: "Edu_CourseLesson",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseLesson_Edu_Course_CourseId",
                table: "Edu_CourseLesson",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
