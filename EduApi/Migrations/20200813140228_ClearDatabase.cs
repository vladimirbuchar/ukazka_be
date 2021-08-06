using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ClearDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummary_Shared_BasicInformation_BasicInformationId",
                table: "Edu_StudentTestSummary");

            migrationBuilder.DropTable(
                name: "Edu_TestStudentResult");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummary_BasicInformationId",
                table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(
                name: "BasicInformationId",
                table: "Edu_StudentTestSummary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BasicInformationId",
                table: "Edu_StudentTestSummary",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_TestStudentResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_TestStudentResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_TestStudentResult_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_TestStudentResult_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_BasicInformationId",
                table: "Edu_StudentTestSummary",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_CourseTestId",
                table: "Edu_TestStudentResult",
                column: "CourseTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_SystemIdentificator",
                table: "Edu_TestStudentResult",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestStudentResult_UserId",
                table: "Edu_TestStudentResult",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummary_Shared_BasicInformation_BasicInformationId",
                table: "Edu_StudentTestSummary",
                column: "BasicInformationId",
                principalTable: "Shared_BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
