using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddUserTestImageAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserTestImageAnswer",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: true);
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[EvaluateAnswer] 
@AnswerId uniqueidentifier,
@AnswerText varchar(max),
@QuestionId uniqueidentifier,
@fileName varchar(max)

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

if  @AnswerId = '00000000-0000-0000-0000-000000000000'
begin
INSERT INTo Edu_StudentTestSummaryAnswer(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,StudentTestSummaryQuestionId,IsActive,Answer,IsTrueAnswer,UserAnswer,UserTestAnswer,Position,UserAnswerIsCorrect,UserTestImageAnswer)
VALUES
(NEWID(),0,0,1,null, @QuestionId,1,'',0,0,@AnswerText,0,0,@fileName)
end
else 
begin
UPDATE Edu_StudentTestSummaryAnswer SET UserAnswer =1,
UserTestAnswer = @AnswerText,
UserAnswerIsCorrect = IsTrueAnswer,
UserTestImageAnswer = @fileName
WHERE Id = @AnswerId
end





COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetStudentAnswer](@StudentTestSummaryQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsa.Id, stsa.Answer,stsa.IsTrueAnswer,stsa.UserAnswer, stsa.UserTestAnswer,stsa.UserAnswerIsCorrect, stsa.FilePath,stsa.UserTestImageAnswer FROM Edu_StudentTestSummaryAnswer AS stsa
WHERE stsa.StudentTestSummaryQuestionId =  @StudentTestSummaryQuestionId AND  stsa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTestImageAnswer",
                table: "Edu_StudentTestSummaryAnswer");
        }
    }
}
