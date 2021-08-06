using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentAnswerAtlerFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetStudentAnswer](@StudentTestSummaryQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsa.Id, ISNULL(stsa.IsTrue,0) AS UserAnswer, stsa.Text, stsa.TestQuestionAnswerId AS AnswerId FROM Edu_StudentTestSummaryAnswer AS stsa
WHERE stsa.StudentTestSummaryQuestionId =  @StudentTestSummaryQuestionId AND  stsa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
