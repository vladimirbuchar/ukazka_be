using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateGetAllStudentInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetAllStudentInGroup (@studentGroupId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cs.Id, p.FirstName, p.LastName,p.SecondName, cs.UserId AS StudentId,u.UserEmail
                            FROM Link_StudentInGroup AS cs
							JOIN Link_UserInOrganization as luin ON  cs.UserId = luin.Id AND luin.IsDeleted = 0
                            JOIN Edu_User AS u ON luin.UserId = u.Id AND u.IsDeleted = 0
                             JOIN Edu_Person AS p ON p.Id = u.PersonId AND p.IsDeleted = 0
                            WHERE cs.StudentGroupId = @studentGroupId AND cs.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
