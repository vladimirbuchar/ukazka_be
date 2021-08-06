using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateTestCompletedIsAutomaticEval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[UpdateTestCompleted]
@StudentTestSummaryId uniqueidentifier

AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION
DECLARE @minimum as int;
declare @testComleted as bit;
declare @Score int;
SET @Score =  (SELECT SUM(Score) FROm Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId =@StudentTestSummaryId AND IsDeleted =0)
SET @minimum = (SELECT TOP(1) ct.DesiredSuccess FROM  Edu_StudentTestSummary  as sts 
JOIN Edu_CourseTest AS ct ON ct.Id = sts.CourseTestId WHERE sts.Id = @StudentTestSummaryId)
set @testComleted = 0
if (@minimum <= @Score) 
set @testComleted = 1


UPDATE Edu_StudentTestSummary SET
Score = @Score,
TestCompleted = @testComleted,
IsAutomaticEvaluate = ISNULL((SELECT TOP(1) IsAutomaticEvaluate FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @StudentTestSummaryId AND IsDeleted = 0 ),1)
WHERE Id =@StudentTestSummaryId
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
