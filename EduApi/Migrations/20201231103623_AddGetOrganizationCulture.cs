using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddGetOrganizationCulture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetOrganizationCulture(@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id, c.Name,oc.IsDefault FROM Cb_Culture AS c
JOIN Link_OrganizationCulture AS oc ON c.Id = oc.CultureId AND oc.IsDeleted = 0
WHERE c.IsDeleted = 0 AND oc.OrganizationId = @organizationId 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
