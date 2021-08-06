using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserTokenAvatrarUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserToken](@userName varchar(max),@password varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id,u.UserToken, p.AvatarUrl, p.FirstName, p.LastName FROM Edu_User AS u
JOIN Edu_Person AS p on p.Id = u.PersonId AND p.IsDeleted = 0 
                             WHERE u.UserEmail = @userName AND u.UserPassword = @password AND u.IsActive = 1 
                                  AND  u.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
