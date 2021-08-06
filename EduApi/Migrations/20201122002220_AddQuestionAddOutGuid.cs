using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddQuestionAddOutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Question, AnswerModeId, BankOfQuestionId) VALUES 
(@Edu_TestQuestion_id, 0, 0, 1, null, @Question, @AnswerModeId, @BankOfQuestionId); 
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
