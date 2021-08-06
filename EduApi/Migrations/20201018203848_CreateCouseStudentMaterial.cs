using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CreateCouseStudentMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_CouseStudentMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CourseLessonItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_CouseStudentMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_CouseStudentMaterial_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_CouseStudentMaterial_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_CourseLessonItemId",
                table: "Link_CouseStudentMaterial",
                column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_SystemIdentificator",
                table: "Link_CouseStudentMaterial",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CouseStudentMaterial_UserId",
                table: "Link_CouseStudentMaterial",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_CouseStudentMaterial");
        }
    }
}
