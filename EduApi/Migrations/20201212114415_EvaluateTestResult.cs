using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateTestResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION EvaluateTestResult(@UserTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Score,  TestCompleted AS Sucess,ISNULL((SELECT TOP(1) IsAutomaticEvaluate FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @UserTestSummaryId AND IsDeleted = 0 AND IsAutomaticEvaluate = 0),1) AS IsAutomatic FROM  Edu_StudentTestSummary WHERE Id = @UserTestSummaryId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
