using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ShowTestResultAlterAddWhere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[ShowTestResult](@userTestId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
 SELECT Id,StartTime,Score,Finish,TestCompleted FROM Edu_StudentTestSummary 
 WHERE Id = @userTestId AND IsDeleted = 0 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
