using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE EvaluateQuestion 
@UserTestSummaryId uniqueidentifier,
@QuestionId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @answerModeId uniqueidentifier;
DECLARE @answerMode varchar(max);
SET @answerModeId = (SELECT AnswerModeId FROM Edu_StudentTestSummaryQuestion WHERE Id = @QuestionId AND IsDeleted = 0)
SET @answerMode = (SELECT SystemIdentificator FROM Cb_AnswerMode WHERE Id =@answerModeId AND IsDeleted = 0)

UPDATE Edu_StudentTestSummaryQuestion SET
StudentTestSummaryId = @UserTestSummaryId
WHERE Id = @QuestionId

DECLARE @answerId uniqueidentifier
DECLARE @isTrueAnswer bit
DECLARE @userAnswer bit

	DECLARE ANSWER_CURSOR CURSOR 
			LOCAL STATIC READ_ONLY FORWARD_ONLY
				FOR 
	SELECT Id,IsTrueAnswer,UserAnswer FROM Edu_StudentTestSummaryAnswer WHERE  IsDeleted = 0 AND StudentTestSummaryQuestionId =@QuestionId 
	
	OPEN ANSWER_CURSOR
	FETCH NEXT FROM ANSWER_CURSOR INTO @answerId,@isTrueAnswer,@userAnswer
	
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		
		
		FETCH NEXT FROM ANSWER_CURSOR INTO @answerId,@isTrueAnswer,@userAnswer
	
	END


		CLOSE ANSWER_CURSOR
	DEALLOCATE ANSWER_CURSOR






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
