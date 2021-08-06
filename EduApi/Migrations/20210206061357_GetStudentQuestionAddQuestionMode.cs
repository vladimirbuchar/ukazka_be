using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentQuestionAddQuestionMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentQuestion](@studentTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsq.Id, stsq.Question, stsq.Score, stsq.IsTrue,am.SystemIdentificator AS AnswerMode,  stsq.IsAutomaticEvaluate,stsq.FilePath,stsq.QuestionModeId, stsq.TestQuestionId,qm.Value AS QuestionMode FROM Edu_StudentTestSummaryQuestion AS stsq
JOIN Cb_AnswerMode AS am ON am.Id = stsq.AnswerModeId AND am.IsDeleted = 0
JOIN Cb_QuestionMode AS qm ON qm.Id = stsq.QuestionModeId AND qm.IsDeleted = 0
WHERE stsq.StudentTestSummaryId  = @studentTestSummaryId AND stsq.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
