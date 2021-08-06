using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStudentQuestion(@studentTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsq.Id, tq.Question, stsq.Score, stsq.IsTrue FROM Edu_StudentTestSummaryQuestion AS stsq
JOIN Edu_TestQuestion AS tq ON tq.Id = stsq.TestQuestionId AND tq.IsDeleted = 0
 WHERE stsq.StudentTestSummaryId  = @studentTestSummaryId AND stsq.IsDeleted = 0

)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
