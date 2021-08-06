using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CreateCouseStudentMaterialAddCourseLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Link_CouseStudentMaterial",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_CourseId",
                table: "Link_CouseStudentMaterial",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_CouseStudentMaterial_Edu_Course_CourseId",
                table: "Link_CouseStudentMaterial",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_CouseStudentMaterial_Edu_Course_CourseId",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Link_CouseStudentMaterial_CourseId",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Link_CouseStudentMaterial");
        }
    }
}
