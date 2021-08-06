using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateAnswerValidateByMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateAnswer]
@Answer nvarchar(max) 
,@IsTrueAnswer bit 
,@AnswerId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @questionMode varchar(max);
DECLARE @TestQuestionId uniqueidentifier;
SET @TestQuestionId = (SELECT TestQuestionId FROM Edu_TestQuestionAnswer WHERE Id = @AnswerId)
set @questionMode =(SELECT AmIdentificator FROM GetQuestionDetail(@TestQuestionId))
if (@questionMode = 'SELECT_ONE' and @IsTrueAnswer =1)
update Edu_TestQuestionAnswer SET IsTrueAnswer = 0 WHERE TestQuestionId = @TestQuestionId 


UPDATE Edu_TestQuestionAnswer SET Answer =@Answer, IsTrueAnswer = @IsTrueAnswer 
WHERE Id = @AnswerId

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
