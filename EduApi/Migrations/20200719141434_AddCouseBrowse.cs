using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCouseBrowse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_CourseBrowse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: true),
                    CourseLessonItemId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CourseBrowse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_CourseBrowse_Edu_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Edu_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_CourseBrowse_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_CourseBrowse_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseBrowse_CourseId",
                table: "Link_CourseBrowse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseBrowse_CourseLessonItemId",
                table: "Link_CourseBrowse",
                column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseBrowse_UserId",
                table: "Link_CourseBrowse",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_CourseBrowse");
        }
    }
}
