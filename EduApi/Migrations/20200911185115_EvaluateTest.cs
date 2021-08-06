using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class EvaluateTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE EvaluateTest
@StudentTestSummaryId uniqueidentifier
, @Score int
, @IsSuccess bit


AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION
UPDATE Edu_StudentTestSummary SET
Score = @Score,
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
