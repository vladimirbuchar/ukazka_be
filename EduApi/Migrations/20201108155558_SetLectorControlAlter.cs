using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetLectorControlAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SetLectorControl]
@QuestionId uniqueidentifier,
@Score int,
@IsTrue bit 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
UPDATE Edu_StudentTestSummaryQuestion SET 
IsTrue =@IsTrue,
Score =@Score,
IsAutomaticEvaluate = 1

WHERE Id = @QuestionId
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
