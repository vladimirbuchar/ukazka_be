using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateUserTestQuestionAddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateUserTestQuestion]
@Question nvarchar(max) 
,@IsAutomaticEvaluate bit 
,@AnswerModeId uniqueidentifier
,@Position int

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestion_id uniqueidentifier 
SET @Edu_TestQuestion_id  = NEWID() 



INSERT INTO Edu_StudentTestSummaryQuestion 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, StudentTestSummaryId,IsAutomaticEvaluate,IsTrue,Score,IsActive,AnswerModeId,Question,Position) VALUES 
(@Edu_TestQuestion_id, 0, 0, 1, null, null,@IsAutomaticEvaluate,0,0,1,@AnswerModeId,@Question,@Position); 
SELECT @Edu_TestQuestion_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateUserTestQuestionAnswer]
@StudentTestSummaryQuestionId uniqueidentifier,
@Answer varchar(max),
@IsTrueAnswer bit, 
@Position int


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 



INSERT INTO Edu_StudentTestSummaryAnswer 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,StudentTestSummaryQuestionId,IsActive,Answer,IsTrueAnswer,UserAnswer,UserTestAnswer,Position,UserAnswerIsCorrect ) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null,@StudentTestSummaryQuestionId,1,@Answer,@IsTrueAnswer,0,'',@Position,0); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

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
