using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateTestAddIsAutomatic : Migration
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
DECLARE @nonAutaticQuestion int
DECLARE @isAutomatic bit
set @isAutomatic = 0
set @IsSuccess = 0
SET @sumScore = (SELECT SUM(Score) FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @StudentTestSummaryId AND IsDeleted = 0) 
SET @nonAutaticQuestion = (SELECT COUNT(IsAutomaticEvaluate) FROM Edu_StudentTestSummaryQuestion WHERE StudentTestSummaryId = @StudentTestSummaryId AND IsDeleted = 0 AND IsAutomaticEvaluate = 0)  
if (@nonAutaticQuestion = 0)
                begin
				set @isAutomatic =1
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
TestCompleted = @IsSuccess,
IsAutomaticEvaluate = @isAutomatic
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
