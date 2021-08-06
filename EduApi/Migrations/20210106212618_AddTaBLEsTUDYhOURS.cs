using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class AddTaBLEsTUDYhOURS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_OrganizationStudyHour",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    ActiveFromId = table.Column<Guid>(nullable: true),
                    ActiveToId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationStudyHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationStudyHour_Cb_TimeTable_ActiveFromId",
                        column: x => x.ActiveFromId,
                        principalTable: "Cb_TimeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationStudyHour_Cb_TimeTable_ActiveToId",
                        column: x => x.ActiveToId,
                        principalTable: "Cb_TimeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationStudyHour_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationStudyHour_ActiveFromId",
                table: "Edu_OrganizationStudyHour",
                column: "ActiveFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationStudyHour_ActiveToId",
                table: "Edu_OrganizationStudyHour",
                column: "ActiveToId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationStudyHour_OrganizationId",
                table: "Edu_OrganizationStudyHour",
                column: "OrganizationId");
            migrationBuilder.SetDefaultTable("Edu_OrganizationStudyHour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_OrganizationStudyHour");
        }
    }
}
