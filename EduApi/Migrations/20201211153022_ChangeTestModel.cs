using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ChangeTestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IsTrue",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrueAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserTestAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "AnswerModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Cb_AnswerMode_AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion",
                column: "AnswerModeId",
                principalTable: "Cb_AnswerMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummaryQuestion_Cb_AnswerMode_AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummaryQuestion_AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "AnswerModeId",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "IsTrueAnswer",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "UserTestAnswer",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.AddColumn<Guid>(
                name: "TestQuestionId",
                table: "Edu_StudentTestSummaryQuestion",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "Edu_StudentTestSummaryAnswer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TestQuestionAnswerId",
                table: "Edu_StudentTestSummaryAnswer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Edu_StudentTestSummaryAnswer",
                type: "nvarchar(max)",
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
    }
}
