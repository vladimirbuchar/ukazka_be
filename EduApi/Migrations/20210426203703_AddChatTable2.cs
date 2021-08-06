using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Core.Extension;

namespace EduApi.Migrations
{
    public partial class AddChatTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CourseTermId = table.Column<Guid>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_Chat_Edu_CourseTerm_CourseTermId",
                        column: x => x.CourseTermId,
                        principalTable: "Edu_CourseTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_Chat_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Chat_CourseTermId",
                table: "Edu_Chat",
                column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Chat_SystemIdentificator",
                table: "Edu_Chat",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Chat_UserId",
                table: "Edu_Chat",
                column: "UserId");
            migrationBuilder.SetDefaultTable("Edu_Chat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_Chat");
        }
    }
}
