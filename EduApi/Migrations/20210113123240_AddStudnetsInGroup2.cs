using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class AddStudnetsInGroup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_StudentInGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    UserId = table.Column<Guid>(nullable: true),
                    StudentGroupId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_StudentInGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroup_Edu_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "Edu_StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_StudentInGroup_Link_UserInOrganization_UserId",
                        column: x => x.UserId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroup_StudentGroupId",
                table: "Link_StudentInGroup",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroup_SystemIdentificator",
                table: "Link_StudentInGroup",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_StudentInGroup_UserId",
                table: "Link_StudentInGroup",
                column: "UserId");
            migrationBuilder.SetDefaultTable("Link_StudentInGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_StudentInGroup");
        }
    }
}
