using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateUserTestQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE CreateUserTestQuestionAnswer
@StudentTestSummaryQuestionId uniqueidentifier,
@Answer varchar(max),
@IsTrueAnswer bit


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 



INSERT INTO Edu_StudentTestSummaryAnswer 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,StudentTestSummaryQuestionId,IsActive,Answer,IsTrueAnswer,UserAnswer,UserTestAnswer ) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null,@StudentTestSummaryQuestionId,1,@Answer,@IsTrueAnswer,0,''); 
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
