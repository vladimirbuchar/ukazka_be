using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyAttendanceChnageIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetMyAttendance](@courseStudentId uniqueidentifier,@courseTermDateId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT IsActive FROM Edu_AttendanceStudent WHERE CourseStudentId = @courseStudentId AND IsDeleted = 0 AND CourseTermDateId = @courseTermDateId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
