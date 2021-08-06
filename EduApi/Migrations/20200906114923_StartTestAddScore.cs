using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class StartTestAddScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[StartTest] 
@StartTime datetime 
,@UserId uniqueidentifier 
,@Finish datetime 
,@TestCompleted bit 
,@CourseTestId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_StudentTestSummary_id uniqueidentifier 
SET @Edu_StudentTestSummary_id  = NEWID() 
INSERT INTO Edu_StudentTestSummary 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, StartTime, UserId, Finish, TestCompleted, CourseTestId,Score) VALUES 
(@Edu_StudentTestSummary_id, 0, 0, 1, null, @StartTime, @UserId, @Finish, @TestCompleted, @CourseTestId,0); 
SELECT @Edu_StudentTestSummary_id AS OutGuid
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
