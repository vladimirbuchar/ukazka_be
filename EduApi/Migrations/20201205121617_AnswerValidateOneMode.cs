using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerValidateOneMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetQuestionDetail](@questionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, tq.BankOfQuestionId, am.SystemIdentificator AS AmIdentificator FROM Edu_TestQuestion as tq
JOIN Cb_AnswerMode AS am ON tq.AnswerModeId = am.Id AND am.IsDeleted = 0
WHERE  tq.Id =@questionId AND tq.IsDeleted = 0

)
");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddAnswer] 
@Answer nvarchar(max) 
,@IsTrueAnswer bit 
,@TestQuestionId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 
DECLARE @questionMode varchar(max);
set @questionMode =(SELECT AmIdentificator FROM GetQuestionDetail(@TestQuestionId))
if (@questionMode = 'SELECT_ONE' and @IsTrueAnswer =1)
update Edu_TestQuestionAnswer SET IsTrueAnswer = 0 WHERE TestQuestionId = @TestQuestionId 


INSERT INTO Edu_TestQuestionAnswer 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Answer, IsTrueAnswer, TestQuestionId) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, @Answer, @IsTrueAnswer, @TestQuestionId); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

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
