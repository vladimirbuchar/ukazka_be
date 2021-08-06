using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserTestQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetUserTestQuestion(@studentTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tqa.Id, tqa.IsTrue, tqa.TestQuestionId FROM Edu_StudentTestSummaryQuestion AS tqa
                WHERE tqa.StudentTestSummaryId = @studentTestSummaryId AND tqa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
