using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentAttendanceAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStudentAttendance (@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseTermDateId,CourseStudentId  FROM Edu_AttendanceStudent WHERE CourseTermId = @courseTermId AND IsDeleted = 0 AND IsActive = 1
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
