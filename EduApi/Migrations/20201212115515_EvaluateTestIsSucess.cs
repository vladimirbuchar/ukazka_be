using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateTestIsSucess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[EvaluateTest]
@StudentTestSummaryId uniqueidentifier

AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION
DECLARE @sumScore int
DECLARE @IsSuccess bit
DECLARE @IsAutomaticEvaluate int
set @IsSuccess = 0
SET @sumScore = (SELECT SUM(Score) FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @StudentTestSummaryId AND IsDeleted = 0) 
SET @IsAutomaticEvaluate = (SELECT COUNT(IsAutomaticEvaluate) FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @StudentTestSummaryId AND IsDeleted = 0 AND IsAutomaticEvaluate = 0)  
if (@IsAutomaticEvaluate = 0)
                begin
                DECLARE @testId uniqueidentifier
DECLARE @desiredSuccess int
SET @testId = (SELECT CourseTestId FROM Edu_StudentTestSummary WHERE Id = @StudentTestSummaryId AND IsDeleted = 0)
SET @desiredSuccess = (SELECT DesiredSuccess FROM Edu_CourseTest WHERE Id = @testId)
if @desiredSuccess = 0 OR @sumScore>= @desiredSuccess
set @IsSuccess = 1
end



UPDATE Edu_StudentTestSummary SET
Score = @sumScore,
Finish = SYSDATETIME(),
TestCompleted = @IsSuccess
WHERE Id = @StudentTestSummaryId
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
