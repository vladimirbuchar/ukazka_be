using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllStudentGroupInTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetAllStudentGroupInTerm(@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseTermId,StudentGroupId FROM Link_StudentInGroupCourseTerm WHERE CourseTermId =@courseTermId AND IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
