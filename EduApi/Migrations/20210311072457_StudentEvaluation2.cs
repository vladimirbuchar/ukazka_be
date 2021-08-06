using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Core.Extension;

namespace EduApi.Migrations
{
    public partial class StudentEvaluation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentEvaluation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    UserInOrganizationId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Evaluation = table.Column<string>(nullable: true),
                    CourseTermId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                        column: x => x.CourseTermId,
                        principalTable: "Edu_CourseTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEvaluation_Link_UserInOrganization_UserInOrganizationId",
                        column: x => x.UserInOrganizationId,
                        principalTable: "Link_UserInOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluation_CourseTermId",
                table: "StudentEvaluation",
                column: "CourseTermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluation_SystemIdentificator",
                table: "StudentEvaluation",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluation_UserInOrganizationId",
                table: "StudentEvaluation",
                column: "UserInOrganizationId");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentEvaluation");
        }
    }
}
