using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetUserOrganizationRoleADddUioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserOrganizationRole](@userId uniqueidentifier,@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eor.Id, eor.SystemIdentificator, uio.Id AS UioId
                           FROM Link_UserInOrganization AS uio
                           JOIN Edu_OrganizationRole AS eor ON uio.OrganizationRoleId = eor.Id
                           WHERE uio.IsDeleted = 0 AND eor.IsDeleted = 0 and uio.OrganizationId = @organizationId 
                                AND uio.UserId =@userId 
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
