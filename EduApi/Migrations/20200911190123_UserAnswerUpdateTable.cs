using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UserAnswerUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutomaticEvaluate",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutomaticEvaluate",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "IsTrue",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "IsTrue",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Edu_StudentTestSummaryAnswer");
        }
    }
}
