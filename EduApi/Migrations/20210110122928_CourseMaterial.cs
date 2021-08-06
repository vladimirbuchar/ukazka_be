using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class CourseMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseMaterialId",
                table: "Edu_CourseLesson",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_CourseMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_CourseMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterial_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_CourseMaterial_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseLesson_CourseMaterialId",
                table: "Edu_CourseLesson",
                column: "CourseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseMaterial_BasicInformationId",
                table: "Edu_CourseMaterial",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_CourseMaterial_OrganizationId",
                table: "Edu_CourseMaterial",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_CourseLesson_Edu_CourseMaterial_CourseMaterialId",
                table: "Edu_CourseLesson",
                column: "CourseMaterialId",
                principalTable: "Edu_CourseMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.SetDefaultTable("Edu_CourseMaterial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_CourseLesson_Edu_CourseMaterial_CourseMaterialId",
                table: "Edu_CourseLesson");

            migrationBuilder.DropTable(
                name: "Edu_CourseMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Edu_CourseLesson_CourseMaterialId",
                table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(
                name: "CourseMaterialId",
                table: "Edu_CourseLesson");
        }
    }
}
