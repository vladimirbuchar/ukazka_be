using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class CreateStudentInGroupCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_StudentInGroupCourseTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    CourseTermId = table.Column<Guid>(nullable: true),
                    StudentGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_StudentInGroupCourseTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroupCourseTerm_Edu_CourseTerm_CourseTermId",
                        column: x => x.CourseTermId,
                        principalTable: "Edu_CourseTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroupCourseTerm_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroupCourseTerm_CourseTermId",
                table: "Link_StudentInGroupCourseTerm",
                column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroupCourseTerm_StudentGroupId",
                table: "Link_StudentInGroupCourseTerm",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroupCourseTerm_SystemIdentificator",
                table: "Link_StudentInGroupCourseTerm",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Link_StudentInGroupCourseTerm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_StudentInGroupCourseTerm");
        }
    }
}
