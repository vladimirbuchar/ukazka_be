using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateQuestionScoreAutomaticOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[EvaluateQuestion] 
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

DECLARE @answerId uniqueidentifier
DECLARE @isTrueAnswer bit
DECLARE @userAnswer bit
DECLARE @userCorrectAnswer bit
set @userCorrectAnswer =1
declare @score int
set @score =1
if @answerMode = 'TEXT'
set @score =0

	DECLARE ANSWER_CURSOR CURSOR 
			LOCAL STATIC READ_ONLY FORWARD_ONLY
				FOR 
	SELECT Id,IsTrueAnswer,UserAnswer FROM Edu_StudentTestSummaryAnswer WHERE  IsDeleted = 0 AND StudentTestSummaryQuestionId =@QuestionId 
	
	OPEN ANSWER_CURSOR
	FETCH NEXT FROM ANSWER_CURSOR INTO @answerId,@isTrueAnswer,@userAnswer
	
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		if @userAnswer != @isTrueAnswer
		begin 
		set @userCorrectAnswer = 0
		set @score =0
		end
		FETCH NEXT FROM ANSWER_CURSOR INTO @answerId,@isTrueAnswer,@userAnswer
	END


		CLOSE ANSWER_CURSOR
	DEALLOCATE ANSWER_CURSOR

UPDATE Edu_StudentTestSummaryQuestion SET
StudentTestSummaryId = @UserTestSummaryId,
IsTrue =@userCorrectAnswer,
Score = @score

WHERE Id = @QuestionId





COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
