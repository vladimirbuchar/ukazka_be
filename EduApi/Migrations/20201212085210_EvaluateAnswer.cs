using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE EvaluateAnswer 
@AnswerId uniqueidentifier,
@AnswerText varchar(max)

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE Edu_StudentTestSummaryAnswer SET UserAnswer =1,
UserTestAnswer = @AnswerText,
UserAnswerIsCorrect = IsTrueAnswer
WHERE Id = @AnswerId





COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
