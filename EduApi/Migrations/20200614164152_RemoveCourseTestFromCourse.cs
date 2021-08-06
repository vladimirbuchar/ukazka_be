using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class RemoveCourseTestFromCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTest_Edu_Course_CourseId",
                table: "Edu_CourseTest");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTest_CourseId",
                table: "Edu_CourseTest");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Edu_CourseTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Edu_CourseTest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_CourseId",
                table: "Edu_CourseTest",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTest_Edu_Course_CourseId",
                table: "Edu_CourseTest",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
