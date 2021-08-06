using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserTestQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetUserTestQuestionAnswer(@studentTestQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tqa.Id, tqa.IsTrue, tqa.TestQuestionAnswerId, tqa.Text FROM Edu_StudentTestSummaryAnswer AS tqa
                WHERE tqa.StudentTestSummaryQuestionId = @studentTestQuestionId AND tqa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
