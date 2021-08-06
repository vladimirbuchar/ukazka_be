using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateQuestionAddBankOfQUestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateQuestion]
@Question nvarchar(max) 
,@AnswerModeId uniqueidentifier
,@QuestionId uniqueidentifier
,@BankOfQuestionId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE Edu_TestQuestion SET 
BankOfQuestionId =@BankOfQuestionId,
Question =@Question, AnswerModeId =@AnswerModeId WHERE Id =@QuestionId


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
