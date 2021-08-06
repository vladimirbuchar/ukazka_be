using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserDetailByEmailAvatarUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserDetailByEmail](@userEmail varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id, u.UserEmail, p.FirstName, p.SecondName, p.LastName, p.Id AS PersonId, p.AvatarUrl
                             FROM Edu_User AS u
                             JOIN Edu_Person AS p ON u.PersonId = p.Id AND p.IsDeleted = 0
                             WHERE u.UserEmail = @userEmail AND u.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
