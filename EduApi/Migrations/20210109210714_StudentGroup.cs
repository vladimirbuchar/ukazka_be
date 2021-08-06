using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class StudentGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_StudentGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroup_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_StudentGroup_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroup_BasicInformationId",
                table: "Edu_StudentGroup",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroup_OrganizationId",
                table: "Edu_StudentGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentGroup_SystemIdentificator",
                table: "Edu_StudentGroup",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Edu_StudentGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_StudentGroup");
        }
    }
}
