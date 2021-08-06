using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetTokenByFacebookIdAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTokenByFacebookId](
@userId uniqueidentifier,
@facebookId varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id, u.UserToken, p.AvatarUrl, p.FirstName,p.LastName FROM Edu_User as u
JOIN Edu_Person AS p ON u.PersonId = p.Id AND p.IsDeleted =0
WHERE u.Id =@userId AND FacebookId = @facebookId AND u.IsDeleted = 0                            
)
");

            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTokenByGoogleId](
@userId uniqueidentifier,
@googleIdkId varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id, u.UserToken, p.AvatarUrl, p.FirstName,p.LastName FROM Edu_User as u
JOIN Edu_Person AS p ON u.PersonId = p.Id AND p.IsDeleted =0
WHERE u.Id =@userId AND GoogleId = @googleIdkId AND u.IsDeleted = 0                            
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
