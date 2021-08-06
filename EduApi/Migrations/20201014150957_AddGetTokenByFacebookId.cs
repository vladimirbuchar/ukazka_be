using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddGetTokenByFacebookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetTokenByFacebookId(
@userId uniqueidentifier,
@facebookId varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT Id, UserToken FROM Edu_User WHERE Id =@userId AND FacebookId = @facebookId AND IsDeleted = 0                            
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
