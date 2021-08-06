using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseTermDateClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassRoomId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLectorId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_ClassRoomId",
                table: "Edu_CourseTermDate",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_CourseLectorId",
                table: "Edu_CourseTermDate",
                column: "CourseLectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Edu_ClassRoom_ClassRoomId",
                table: "Edu_CourseTermDate",
                column: "ClassRoomId",
                principalTable: "Edu_ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTermDate",
                column: "CourseLectorId",
                principalTable: "Link_CourseLector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Edu_ClassRoom_ClassRoomId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Link_CourseLector_CourseLectorId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_ClassRoomId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_CourseLectorId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "CourseLectorId",
                table: "Edu_CourseTermDate");
        }
    }
}
