using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class JoinjUserAnswerTOOnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "TestQuestionAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer",
                column: "TestQuestionAnswerId",
                principalTable: "Edu_TestQuestionAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Edu_TestQuestion_TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "TestQuestionId",
                principalTable: "Edu_TestQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryAnswer_Edu_TestQuestionAnswer_TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Edu_TestQuestion_TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummaryAnswer_TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer");
        }
    }
}
