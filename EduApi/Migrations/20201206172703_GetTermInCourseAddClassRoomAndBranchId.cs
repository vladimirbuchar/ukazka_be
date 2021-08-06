using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetTermInCourseAddClassRoomAndBranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTermInCourse](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT t.Id,t.CourseId, ttTo.Value AS TimeTo, ttFrom.Value AS TimeFrom, cbi.Name AS ClassRoom, bsi.Name AS Branch,
t.ActiveFrom, t.ActiveTo, t.Friday,t.Monday,t.Thursday,t.Wednesday,t.Tuesday,t.Sunday,t.Saturday, b.Id AS BranchId, c.Id AS ClassRoomId
                           FROM Edu_CourseTerm AS t
						   LEFT JOIN Cb_TimeTable AS ttTo ON t.TimeToId  = ttTo.Id   AND ttTo.IsDeleted = 0
						   LEFT JOIN Cb_TimeTable AS ttFrom ON t.TimeFromId  = ttFrom.Id AND ttFrom.IsDeleted = 0
						   LEFT JOIN Edu_ClassRoom AS c ON t.ClassRoomId = c.Id AND c.IsDeleted = 0
						   LEFT JOIN Shared_BasicInformation AS cbi ON c.BasicInformationId =  cbi.Id AND cbi.IsDeleted =0
						   LEFT JOIN Edu_Branch AS b ON b.Id = c.BranchId  AND b.IsDeleted = 0
						   LEFT JOIN Shared_BasicInformation AS bsi ON b.BasicInformationId = bsi.Id AND bsi.IsDeleted = 0
						   

                           WHERE t.CourseId = @courseId AND t.IsDeleted =0
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
