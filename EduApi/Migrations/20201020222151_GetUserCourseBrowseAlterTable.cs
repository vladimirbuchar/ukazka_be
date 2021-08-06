using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserCourseBrowseAlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserCourseBrowse](@UserId uniqueidentifier,@CouurseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseLessonItemId FROM Link_CouseStudentMaterial WHERE IsDeleted = 0 AND UserId =@UserId AND CourseId = @CouurseId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
