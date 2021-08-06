using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserCourseBrowseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserCourseBrowse](@UserId uniqueidentifier,@CouurseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseLessonItem FROM Link_CouseStudentMaterial  AS lcsm
WHERE lcsm.IsDeleted = 0 AND UserId =@UserId AND lcsm.CourseId = @CouurseId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
