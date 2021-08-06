using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateUserTestQuestionSaveColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateUserTestQuestion]
@Question nvarchar(max) 
,@IsAutomaticEvaluate bit 
,@AnswerModeId uniqueidentifier
,@Position int
,@QuestionId uniqueidentifier,
@QuestionModeId uniqueidentifier,
@FilePath nvarchar(max) 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestion_id uniqueidentifier 
SET @Edu_TestQuestion_id  = NEWID() 



INSERT INTO Edu_StudentTestSummaryQuestion 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, StudentTestSummaryId,IsAutomaticEvaluate,IsTrue,Score,IsActive,AnswerModeId,Question,Position,TestQuestionId,FilePath,QuestionModeId) VALUES 
(@Edu_TestQuestion_id, 0, 0, 1, null, null,@IsAutomaticEvaluate,0,0,1,@AnswerModeId,@Question,@Position,@QuestionId,@FilePath,@QuestionModeId); 
SELECT @Edu_TestQuestion_id AS OutGuid

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
