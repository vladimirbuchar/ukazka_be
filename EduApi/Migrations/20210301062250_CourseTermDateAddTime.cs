using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CourseTermDateAddTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TimeFromId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TimeToId",
                table: "Edu_CourseTermDate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_TimeFromId",
                table: "Edu_CourseTermDate",
                column: "TimeFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_TimeToId",
                table: "Edu_CourseTermDate",
                column: "TimeToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeFromId",
                table: "Edu_CourseTermDate",
                column: "TimeFromId",
                principalTable: "Cb_TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeToId",
                table: "Edu_CourseTermDate",
                column: "TimeToId",
                principalTable: "Cb_TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeFromId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTermDate_Cb_TimeTable_TimeToId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_TimeFromId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTermDate_TimeToId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "TimeFromId",
                table: "Edu_CourseTermDate");

            migrationBuilder.DropColumn(
                name: "TimeToId",
                table: "Edu_CourseTermDate");
        }
    }
}
