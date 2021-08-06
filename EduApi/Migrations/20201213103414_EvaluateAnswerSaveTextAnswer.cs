using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateAnswerSaveTextAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[EvaluateAnswer] 
@AnswerId uniqueidentifier,
@AnswerText varchar(max),
@QuestionId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

if  @AnswerId = '00000000-0000-0000-0000-000000000000'
begin
INSERT INTo Edu_StudentTestSummaryAnswer(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,StudentTestSummaryQuestionId,IsActive,Answer,IsTrueAnswer,UserAnswer,UserTestAnswer,Position,UserAnswerIsCorrect)
VALUES
(NEWID(),0,0,1,null, @QuestionId,1,'',0,0,@AnswerText,0,0)
end
else 
begin
UPDATE Edu_StudentTestSummaryAnswer SET UserAnswer =1,
UserTestAnswer = @AnswerText,
UserAnswerIsCorrect = IsTrueAnswer
WHERE Id = @AnswerId
end





COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
