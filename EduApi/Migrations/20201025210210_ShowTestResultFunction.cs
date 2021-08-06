using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ShowTestResultFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  FUNCTION ShowTestResult(@userTestId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
 SELECT Id,StartTime,Score,Finish,TestCompleted FROM Edu_StudentTestSummary 
 WHERE IsDeleted = 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
