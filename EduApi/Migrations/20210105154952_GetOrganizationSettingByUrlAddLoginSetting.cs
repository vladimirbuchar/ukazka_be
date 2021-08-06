using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSettingByUrlAddLoginSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSettingByUrl](@url varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id,sbi.Name,os.FacebookLogin,os.GoogleLogin,os.Registration,os.PasswordReset  FROM Edu_OrganizationSetting AS os 
JOIN Edu_Organization AS o ON os.OrganizationId = o.Id AND o.IsDeleted = 0
JOIN Shared_BasicInformation AS sbi ON sbi.Id = o.BasicInformationId AND sbi.IsDeleted = 0
WHERE os.ElearningUrl =@url AND os.IsDeleted =0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
