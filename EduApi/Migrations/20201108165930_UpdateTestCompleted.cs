using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateTestCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateTestCompleted
@StudentTestSummaryId uniqueidentifier
, @Score int

AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION
DECLARE @minimum as int;
declare @testComleted as bit;
SET @minimum = (SELECT TOP(1) ct.DesiredSuccess FROM  Edu_StudentTestSummary  as sts 
JOIN Edu_CourseTest AS ct ON ct.Id = sts.CourseTestId WHERE sts.Id = @StudentTestSummaryId)
set @testComleted = 0
if (@minimum >= @Score) 
set @testComleted = 1


UPDATE Edu_StudentTestSummary SET
Score = @Score,
Finish = SYSDATETIME(),
TestCompleted = @testComleted
WHERE Id = @StudentTestSummaryId
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
