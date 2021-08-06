using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserCourseBrowseAddItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserCourseBrowse](@UserId uniqueidentifier,@CouurseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseLessonItemId, clit.SystemIdentificator AS ItemType FROM Link_CouseStudentMaterial  AS lcsm
JOIN Edu_CourseLessonItem AS ecli ON ecli.Id = lcsm.CourseLessonItemId
JOIN Cb_CourseLessonItemTemplate AS clit ON clit.Id = ecli.CourseLessonItemTemplateId
WHERE lcsm.IsDeleted = 0 AND UserId =@UserId AND CourseId = @CouurseId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
