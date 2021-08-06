using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddPositionToStudentTestSummaryQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UserAnswerIsCorrect",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "UserAnswerIsCorrect",
                table: "Edu_StudentTestSummaryAnswer");
        }
    }
}
