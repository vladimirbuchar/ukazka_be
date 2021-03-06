using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetCourseLessonItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseLessonItems](@CourseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ci.Id,  sbi.Name, sbi.Description FROM Edu_CourseLessonItem AS ci
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
                  WHERE ci.CourseLessonId = @CourseLessonId AND ci.IsDeleted = 0
)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
