using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetBankOfQuestionAddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetBankOfQuestion](@CourseTestId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT  Id, BankOfQuestionId FROM Link_TestBankOfQuestion WHERE CourseTestId=@CourseTestId AND IsDeleted= 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
