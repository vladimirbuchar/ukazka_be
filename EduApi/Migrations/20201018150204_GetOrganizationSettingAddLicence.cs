using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSettingAddLicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSetting](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT OrganizationId,UserDefaultPassword, eo.LicenseId  from Edu_OrganizationSetting as eos
join Edu_Organization  eo ON eos.OrganizationId = eo.Id and eos.IsDeleted =0 
WHERE eo.IsDeleted= 0 AND OrganizationId =@OrganizationId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
