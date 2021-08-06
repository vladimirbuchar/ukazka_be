using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentAnswerChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetStudentAnswer](@StudentTestSummaryQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsa.Id, stsa.Answer,stsa.IsTrueAnswer,stsa.UserAnswer, stsa.UserTestAnswer,stsa.UserAnswerIsCorrect FROM Edu_StudentTestSummaryAnswer AS stsa
WHERE stsa.StudentTestSummaryQuestionId =  @StudentTestSummaryQuestionId AND  stsa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
