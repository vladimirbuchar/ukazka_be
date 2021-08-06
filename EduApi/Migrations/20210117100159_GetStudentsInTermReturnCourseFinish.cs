using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentsInTermReturnCourseFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentsInTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cs.Id, p.FirstName, p.LastName,p.SecondName, cs.UserId AS StudentId,u.UserEmail, cs.CourseFinish
                            FROM Link_CourseStudent AS cs
							JOIN Link_UserInOrganization as luin ON  cs.UserId = luin.Id AND luin.IsDeleted = 0
                            JOIN Edu_User AS u ON luin.UserId = u.Id AND u.IsDeleted = 0
                             JOIN Edu_Person AS p ON p.Id = u.PersonId AND p.IsDeleted = 0
                            WHERE cs.CourseTermId = @courseTermId AND cs.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
