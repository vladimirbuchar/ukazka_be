using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class CourseTermDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseTermDateId",
                table: "Edu_CourseTerm",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_CourseTermDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseTermDate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTerm_CourseTermDateId",
                table: "Edu_CourseTerm",
                column: "CourseTermDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseTermDate_SystemIdentificator",
                table: "Edu_CourseTermDate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseTerm_Edu_CourseTermDate_CourseTermDateId",
                table: "Edu_CourseTerm",
                column: "CourseTermDateId",
                principalTable: "Edu_CourseTermDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.SetDefaultTable("Edu_CourseTermDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseTerm_Edu_CourseTermDate_CourseTermDateId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropTable(
                name: "Edu_CourseTermDate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseTerm_CourseTermDateId",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "CourseTermDateId",
                table: "Edu_CourseTerm");
        }
    }
}
