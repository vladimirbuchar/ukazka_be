using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCertificateInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetCertificateInOrganization (@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ec.Id,Html, sbi.Name FROM Edu_Certificate AS	ec
JOIN Shared_BasicInformation AS sbi ON ec.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE ec.OrganizationId = @OrganizationId AND ec.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
