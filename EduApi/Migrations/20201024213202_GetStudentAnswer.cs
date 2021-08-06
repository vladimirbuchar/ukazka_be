using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStudentAnswer(@StudentTestSummaryQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsa.Id, tqa.Answer, tqa.IsTrueAnswer,ISNULL(stsa.IsTrue,0) AS UserAnswer, stsa.Text FROM Edu_TestQuestionAnswer AS tqa
LEFT JOIN Edu_StudentTestSummaryAnswer AS stsa ON tqa.Id = stsa.TestQuestionAnswerId  AND stsa.IsDeleted = 0
WHERE stsa.StudentTestSummaryQuestionId =  @StudentTestSummaryQuestionId AND  tqa.IsDeleted = 0
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
