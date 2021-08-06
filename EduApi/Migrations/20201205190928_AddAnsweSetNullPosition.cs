using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddAnsweSetNullPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Answer, IsTrueAnswer, TestQuestionId,Position) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, @Answer, @IsTrueAnswer, @TestQuestionId,ISNULL((SELECT MAX(Position) FROM Edu_TestQuestionAnswer WHERE TestQuestionId = @TestQuestionId),0)+1); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddQuestion]
@Question nvarchar(max) 
,@AnswerModeId uniqueidentifier
,@BankOfQuestionId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestion_id uniqueidentifier 
SET @Edu_TestQuestion_id  = NEWID() 
INSERT INTO Edu_TestQuestion 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Question, AnswerModeId, BankOfQuestionId,Position) VALUES 
(@Edu_TestQuestion_id, 0, 0, 1, null, @Question, @AnswerModeId, @BankOfQuestionId, ISNULL((SELECT MAX(Position) FROM Edu_TestQuestion WHERE BankOfQuestionId = @BankOfQuestionId),0)+1 ); 
SELECT @Edu_TestQuestion_id AS OutGuid

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
