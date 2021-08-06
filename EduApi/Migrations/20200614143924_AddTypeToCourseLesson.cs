using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddTypeToCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTest_Shared_BasicInformation_BasicInformationId",
                table: "Edu_CourseTest");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTest_BasicInformationId",
                table: "Edu_CourseTest");

            migrationBuilder.DropColumn(
                name: "BasicInformationId",
                table: "Edu_CourseTest");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonId",
                table: "Edu_CourseTest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Edu_CourseLesson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_CourseLessonId",
                table: "Edu_CourseTest",
                column: "CourseLessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTest_Edu_CourseLesson_CourseLessonId",
                table: "Edu_CourseTest",
                column: "CourseLessonId",
                principalTable: "Edu_CourseLesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTest_Edu_CourseLesson_CourseLessonId",
                table: "Edu_CourseTest");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTest_CourseLessonId",
                table: "Edu_CourseTest");

            migrationBuilder.DropColumn(
                name: "CourseLessonId",
                table: "Edu_CourseTest");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Edu_CourseLesson");

            migrationBuilder.AddColumn<Guid>(
                name: "BasicInformationId",
                table: "Edu_CourseTest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTest_BasicInformationId",
                table: "Edu_CourseTest",
                column: "BasicInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTest_Shared_BasicInformation_BasicInformationId",
                table: "Edu_CourseTest",
                column: "BasicInformationId",
                principalTable: "Shared_BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
