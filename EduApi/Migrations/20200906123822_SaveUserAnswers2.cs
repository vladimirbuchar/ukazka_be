using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class SaveUserAnswers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Link_TestBankOfQuestion",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Link_TestBankOfQuestion",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Link_TestBankOfQuestion",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Link_CourseBrowse",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Link_CourseBrowse",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Link_CourseBrowse",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Edu_FileRepository",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Edu_FileRepository",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Edu_FileRepository",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Cb_CourseLessonItemTemplate",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cb_CourseLessonItemTemplate",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Cb_CourseLessonItemTemplate",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummaryQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    StudentTestSummaryId = table.Column<Guid>(nullable: true),
                    TestQuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummaryQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Edu_StudentTestSummary_StudentTestSummaryId",
                        column: x => x.StudentTestSummaryId,
                        principalTable: "Edu_StudentTestSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryQuestion_Edu_TestQuestion_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "Edu_TestQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edu_StudentTestSummaryAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    TestQuestionAnswerId = table.Column<Guid>(nullable: true),
                    StudentTestSummaryQuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_StudentTestSummaryAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryAnswer_Edu_StudentTestSummaryQuestion_StudentTestSummaryQuestionId",
                        column: x => x.StudentTestSummaryQuestionId,
                        principalTable: "Edu_StudentTestSummaryQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_StudentTestSummaryAnswer_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                        column: x => x.TestQuestionAnswerId,
                        principalTable: "Edu_TestQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_TestBankOfQuestion_SystemIdentificator",
                table: "Link_TestBankOfQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Link_CourseBrowse_SystemIdentificator",
                table: "Link_CourseBrowse",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_FileRepository_SystemIdentificator",
                table: "Edu_FileRepository",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_CourseLessonItemTemplate_SystemIdentificator",
                table: "Cb_CourseLessonItemTemplate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_StudentTestSummaryQuestionId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "StudentTestSummaryQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_SystemIdentificator",
                table: "Edu_StudentTestSummaryAnswer",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "TestQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_StudentTestSummaryId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "StudentTestSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_SystemIdentificator",
                table: "Edu_StudentTestSummaryQuestion",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "TestQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropTable(
                name: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Link_TestBankOfQuestion_SystemIdentificator",
                table: "Link_TestBankOfQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Link_CourseBrowse_SystemIdentificator",
                table: "Link_CourseBrowse");

            migrationBuilder.DropIndex(
                name: "IX_Edu_FileRepository_SystemIdentificator",
                table: "Edu_FileRepository");

            migrationBuilder.DropIndex(
                name: "IX_Cb_CourseLessonItemTemplate_SystemIdentificator",
                table: "Cb_CourseLessonItemTemplate");

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Link_TestBankOfQuestion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Link_TestBankOfQuestion",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Link_TestBankOfQuestion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Link_CourseBrowse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Link_CourseBrowse",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Link_CourseBrowse",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Edu_FileRepository",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Edu_FileRepository",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Edu_FileRepository",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemIdentificator",
                table: "Cb_CourseLessonItemTemplate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Cb_CourseLessonItemTemplate",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsChanged",
                table: "Cb_CourseLessonItemTemplate",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);
        }
    }
}
