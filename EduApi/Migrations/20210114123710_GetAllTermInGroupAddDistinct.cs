using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllTermInGroupAddDistinct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllTermInGroup](@studentGroupId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT DISTINCT CourseTermId FROM Link_StudentInGroupCourseTerm WHERE StudentGroupId = @studentGroupId AND IsDeleted =0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
