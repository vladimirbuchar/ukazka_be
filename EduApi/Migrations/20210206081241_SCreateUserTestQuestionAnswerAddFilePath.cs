using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SCreateUserTestQuestionAnswerAddFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateUserTestQuestionAnswer]
@StudentTestSummaryQuestionId uniqueidentifier,
@Answer varchar(max),
@IsTrueAnswer bit, 
@Position int,
@AnswerId uniqueidentifier,
@FilePath varchar(max)


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 



INSERT INTO Edu_StudentTestSummaryAnswer 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,StudentTestSummaryQuestionId,IsActive,Answer,IsTrueAnswer,UserAnswer,UserTestAnswer,Position,UserAnswerIsCorrect,TestQuestionAnswerId,FilePath) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null,@StudentTestSummaryQuestionId,1,@Answer,@IsTrueAnswer,0,'',@Position,0,@AnswerId,@FilePath); 
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
