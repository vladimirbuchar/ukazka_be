using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseLessonCourseMaterialId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLesson](@courseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                                  FROM Edu_Organization AS o
                            JOIN Edu_CourseMaterial AS c ON o.Id = c.OrganizationId AND c.IsDeleted = 0
							JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId AND cl.IsDeleted = 0
                            WHERE cl.Id = @courseLessonId   AND o.IsDeleted = 0 
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
