using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyAttendanceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION GetMyAttendance(@courseStudentId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id,IsActive,CourseTermDateId FROM Edu_AttendanceStudent WHERE CourseStudentId = @courseStudentId AND IsDeleted = 0
)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
