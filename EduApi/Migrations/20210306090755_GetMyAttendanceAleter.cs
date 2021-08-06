using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyAttendanceAleter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION GetMyAttendance(@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ctd.Date,ctd.DayOfWeek,eas.IsActive,ttf.Value AS TimeFrom, ttt.Value AS TimeTo FROM  Edu_CourseTermDate AS ctd

LEFT JOIN Edu_AttendanceStudent AS eas on ctd.Id = eas.CourseTermDateId  AND ctd.IsCanceled = 0
JOIN Cb_TimeTable AS ttf ON ctd.TimeFromId = ttf.Id AND ttf.IsDeleted = 0
 JOIN Cb_TimeTable AS ttt ON ctd.TimeToId = ttt.Id AND ttt.IsDeleted = 0
 JOIN Link_CourseStudent AS lcs ON eas.CourseStudentId = lcs.Id  AND lcs.IsDeleted = 0 
 JOIN Link_UserInOrganization AS uio ON uio.Id  = lcs.UserId 
WHERE eas.IsDeleted = 0  AND  uio.UserId = @userId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
