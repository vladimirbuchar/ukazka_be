using System;
using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddNote2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    Text = table.Column<bool>(nullable: false),
                    IsFile = table.Column<bool>(nullable: false),
                    CourseLessonItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Note_Edu_CourseLessonItem_CourseLessonItemId",
                        column: x => x.CourseLessonItemId,
                        principalTable: "Edu_CourseLessonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_CourseLessonItemId",
                table: "Edu_Note",
                column: "CourseLessonItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_SystemIdentificator",
                table: "Edu_Note",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Edu_Note");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_Note");
        }
    }
}
