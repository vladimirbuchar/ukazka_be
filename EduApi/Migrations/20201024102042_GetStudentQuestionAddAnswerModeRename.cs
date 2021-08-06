using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentQuestionAddAnswerModeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION GetStudentQuestion(@studentTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsq.Id, tq.Question, stsq.Score, stsq.IsTrue,am.SystemIdentificator AS AnswerMode FROM Edu_StudentTestSummaryQuestion AS stsq
JOIN Edu_TestQuestion AS tq ON tq.Id = stsq.TestQuestionId AND tq.IsDeleted = 0
JOIN Cb_AnswerMode AS am ON am.Id = tq.AnswerModeId
 WHERE stsq.StudentTestSummaryId  = @studentTestSummaryId AND stsq.IsDeleted = 0

)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
