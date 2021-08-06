using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserCourseBrowseChangeColumnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserCourseBrowse](@UserId uniqueidentifier,@CouurseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseLessonItem, ecl.Type AS ItemType  FROM Link_CouseStudentMaterial  AS lcsm
JOIN Edu_CourseLessonItem AS ecli ON ecli.Id = lcsm.CourseLessonItem AND ecli.IsDeleted = 0
JOIN Edu_CourseLesson AS ecl ON ecl.Id = ecli.CourseLessonId AND ecl.IsDeleted = 0
JOIN Cb_CourseLessonItemTemplate AS clit ON clit.Id = ecli.CourseLessonItemTemplateId AND clit.IsDeleted = 0
WHERE lcsm.IsDeleted = 0 AND UserId =@UserId AND lcsm.CourseId = @CouurseId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
