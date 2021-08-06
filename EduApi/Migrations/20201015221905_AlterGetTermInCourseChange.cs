using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetTermInCourseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTermInCourse](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT t.Id,t.CourseId, ttTo.Value AS TimeTo, ttFrom.Value AS TimeFrom, cbi.Name AS ClassRoom, bsi.Name AS Branch
                           FROM Edu_CourseTerm AS t
						   LEFT JOIN Cb_TimeTable AS ttTo ON t.TimeToId  = ttTo.Id  
						   LEFT JOIN Cb_TimeTable AS ttFrom ON t.TimeFromId  = ttFrom.Id
						   LEFT JOIN Edu_ClassRoom AS c ON t.ClassRoomId = c.Id
						   LEFT JOIN Shared_BasicInformation AS cbi ON c.BasicInformationId =  cbi.Id
						   LEFT JOIN Edu_Branch AS b ON b.Id = c.BranchId 
						   LEFT JOIN Shared_BasicInformation AS bsi ON b.BasicInformationId = bsi.Id
						   

                           WHERE t.CourseId = @courseId AND t.IsDeleted =0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
