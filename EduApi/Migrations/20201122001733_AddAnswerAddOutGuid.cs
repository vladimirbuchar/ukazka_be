using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddAnswerAddOutGuid : Migration
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
INSERT INTO Edu_TestQuestionAnswer 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Answer, IsTrueAnswer, TestQuestionId) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, @Answer, @IsTrueAnswer, @TestQuestionId); 
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
