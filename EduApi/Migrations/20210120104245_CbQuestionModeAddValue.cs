using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CbQuestionModeAddValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuestionModeId",
                table: "Edu_TestQuestion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_TestQuestion_QuestionModeId",
                table: "Edu_TestQuestion",
                column: "QuestionModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_TestQuestion_Cb_QuestionMode_QuestionModeId",
                table: "Edu_TestQuestion",
                column: "QuestionModeId",
                principalTable: "Cb_QuestionMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_TestQuestion_Cb_QuestionMode_QuestionModeId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropIndex(
                name: "IX_Edu_TestQuestion_QuestionModeId",
                table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionModeId",
                table: "Edu_TestQuestion");
        }
    }
}
