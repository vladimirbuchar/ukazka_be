using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyAttendanceAddTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetMyAttendance](@courseStudentId uniqueidentifier,@courseTermDateId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eas.IsActive, ctd.Date,ctd.DayOfWeek, ttf.Value AS TimeFrom, ttt.Value AS TimeTo FROM Edu_AttendanceStudent AS eas
JOIN Edu_CourseTermDate AS ctd ON eas.CourseTermDateId = ctd.Id AND ctd.IsDeleted = 0
JOIN Cb_TimeTable AS ttf ON ttf.Id = ctd.TimeFromId AND ttf.IsDeleted = 0
JOIN Cb_TimeTable AS ttt ON ttt.Id = ctd.TimeToId AND ttt.IsDeleted = 0
WHERE eas.CourseStudentId = @courseStudentId AND eas.IsDeleted = 0 AND eas.CourseTermDateId = @courseTermDateId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
