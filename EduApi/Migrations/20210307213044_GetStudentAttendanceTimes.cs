using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentAttendanceTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentAttendance] (@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eas.CourseTermDateId,eas.CourseStudentId,ttf.Value AS TimeFrom, ttt.Value As TimeTo, ctd.Date, ctd.DayOfWeek  FROM Edu_AttendanceStudent AS eas
JOIN Edu_CourseTermDate AS ctd ON eas.CourseTermDateId = ctd.Id AND ctd.IsDeleted = 0
JOIN Cb_TimeTable AS ttf ON ttf.Id = ctd.TimeFromId AND ttf.IsDeleted = 0
JOIN Cb_TimeTable AS ttt ON ttt.Id = ctd.TimeToId AND ttt.IsDeleted = 0
WHERE eas.CourseTermId = @courseTermId AND eas.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
