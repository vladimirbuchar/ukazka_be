using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddQuestionQuestionMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddQuestion]
@Question nvarchar(max) 
,@AnswerModeId uniqueidentifier
,@BankOfQuestionId uniqueidentifier 
,@QuestionModeId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestion_id uniqueidentifier 
SET @Edu_TestQuestion_id  = NEWID() 
INSERT INTO Edu_TestQuestion 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Question, AnswerModeId, BankOfQuestionId,Position,QuestionModeId) VALUES 
(@Edu_TestQuestion_id, 0, 0, 1, null, @Question, @AnswerModeId, @BankOfQuestionId, ISNULL((SELECT MAX(Position) FROM Edu_TestQuestion WHERE BankOfQuestionId = @BankOfQuestionId),0)+1,@QuestionModeId ); 
SELECT @Edu_TestQuestion_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateQuestion]
@Question nvarchar(max) 
,@AnswerModeId uniqueidentifier
,@QuestionId uniqueidentifier
,@BankOfQuestionId uniqueidentifier
,@QuestionModeId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE Edu_TestQuestion SET 
BankOfQuestionId =@BankOfQuestionId,
Question =@Question, AnswerModeId =@AnswerModeId,
QuestionModeId = @QuestionModeId

WHERE Id =@QuestionId


COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetQuestionDetail](@questionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, tq.BankOfQuestionId, am.SystemIdentificator AS AmIdentificator, tq.QuestionModeId FROM Edu_TestQuestion as tq
JOIN Cb_AnswerMode AS am ON tq.AnswerModeId = am.Id AND am.IsDeleted = 0
WHERE  tq.Id =@questionId AND tq.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
