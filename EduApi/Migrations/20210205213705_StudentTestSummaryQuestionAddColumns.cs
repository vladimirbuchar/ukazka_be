using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class StudentTestSummaryQuestionAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "QuestionModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Cb_QuestionMode_QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "QuestionModeId",
                principalTable: "Cb_QuestionMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Cb_QuestionMode_QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionModeId",
                table: "Edu_StudentTestSummaryQuestion");
        }
    }
}
