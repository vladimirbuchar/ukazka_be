using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseLessonItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLessonItem](@courseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.OrganizationId AS Id
                   FROM  Edu_CourseMaterial AS c 
                   JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseMaterialId AND cl.IsDeleted = 0
                    JOIN Edu_CourseLessonItem AS ci ON cl.Id = ci.CourseLessonId AND ci.IsDeleted = 0
                   WHERE ci.Id = @courseLessonItemId AND c.IsDeleted =0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
