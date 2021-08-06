using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSettingDefaultCultureAddLeftJopin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSetting](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eos.OrganizationId,eos.UserDefaultPassword, eo.LicenseId, dco.CultureId AS DefaultCulture  from Edu_OrganizationSetting as eos
join Edu_Organization  eo ON eos.OrganizationId = eo.Id and eo.IsDeleted =0 
left join Link_OrganizationCulture AS dco ON dco.OrganizationId = eo.Id AND dco.IsDeleted = 0 AND dco.IsDefault = 1
WHERE eos.IsDeleted= 0 AND eos.OrganizationId =@OrganizationId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
