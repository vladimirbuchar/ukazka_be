using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddGetTokenByGoogleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetTokenByGoogleId(
@userId uniqueidentifier,
@googleIdkId varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT Id, UserToken FROM Edu_User WHERE Id =@userId AND GoogleId = @googleIdkId AND IsDeleted = 0                            
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
