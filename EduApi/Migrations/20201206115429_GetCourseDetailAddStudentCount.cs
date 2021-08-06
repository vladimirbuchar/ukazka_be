using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseDetailAddStudentCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseDetail](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.IsPrivateCourse, bi.Name, bi.Description, cp.Price, cp.Sale,
                                  c.CourseStatusId,c.CourseTypeId,
								  sc.MaximumStudent, sc.MinimumStudent
								    FROM Edu_Course AS c
                            JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                            JOIN Shared_CoursePrice AS cp ON c.CoursePriceId = cp.Id AND cp.IsDeleted = 0
                            JOIN Shared_StudentCount AS sc ON c.StudentCountId = sc.Id  AND sc.IsDeleted = 0
                        WHERE c.Id = @courseId AND c.IsDeleted = 0 
                                
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
