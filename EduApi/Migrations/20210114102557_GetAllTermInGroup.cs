using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllTermInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetAllTermInGroup(@studentGroupId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseTermId FROM Link_StudentInGroupCourseTerm WHERE StudentGroupId = @studentGroupId AND IsDeleted =0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
