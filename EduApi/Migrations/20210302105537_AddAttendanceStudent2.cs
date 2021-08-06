using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddAttendanceStudent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_AttendanceStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    CourseTermDateId = table.Column<Guid>(nullable: true),
                    CourseStudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_AttendanceStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_AttendanceStudent_Link_CourseStudent_CourseStudentId",
                        column: x => x.CourseStudentId,
                        principalTable: "Link_CourseStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_AttendanceStudent_Edu_CourseTermDate_CourseTermDateId",
                        column: x => x.CourseTermDateId,
                        principalTable: "Edu_CourseTermDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AttendanceStudent_CourseStudentId",
                table: "Edu_AttendanceStudent",
                column: "CourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AttendanceStudent_CourseTermDateId",
                table: "Edu_AttendanceStudent",
                column: "CourseTermDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_AttendanceStudent_SystemIdentificator",
                table: "Edu_AttendanceStudent",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Edu_AttendanceStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_AttendanceStudent");
        }
    }
}
