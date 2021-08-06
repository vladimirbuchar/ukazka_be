using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ChangeCourseStudentMaterilLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CouseStudentMaterial_Edu_CourseLessonItem_CourseLessonItemId",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Link_CouseStudentMaterial_CourseLessonItemId",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(
                name: "CourseLessonItemId",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonItem",
                table: "Link_CouseStudentMaterial",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseLessonItem",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonItemId",
                table: "Link_CouseStudentMaterial",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_CourseLessonItemId",
                table: "Link_CouseStudentMaterial",
                column: "CourseLessonItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CouseStudentMaterial_Edu_CourseLessonItem_CourseLessonItemId",
                table: "Link_CouseStudentMaterial",
                column: "CourseLessonItemId",
                principalTable: "Edu_CourseLessonItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
