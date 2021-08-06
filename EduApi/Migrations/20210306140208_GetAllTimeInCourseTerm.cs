using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllTimeInCourseTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetAllTimeInCourseTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ctd.Id,ctd.Date FROM Edu_CourseTermDate AS ctd 
WHERE ctd.CourseTermId = @courseTermId AND ctd.IsDeleted = 0 AND ctd.IsCanceled = 0
                             
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
