using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllStudentGroupInTerm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllStudentGroupInTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id, CourseTermId,StudentGroupId FROM Link_StudentInGroupCourseTerm WHERE CourseTermId =@courseTermId AND IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
