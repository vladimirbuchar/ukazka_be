using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseLessonCourseMaterialId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLesson](@courseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT  m.OrganizationId AS Id
  FROM Edu_CourseLesson as c
  JOIN Edu_CourseMaterial AS m ON c.CourseMaterialId = m.Id AND m.IsDeleted =0
  WHERE c.Id =@courseLessonId  AND c.IsDeleted = 0
  )
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
