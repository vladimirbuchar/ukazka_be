using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSettingBackgroung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Edu_OrganizationSetting");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSetting](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eos.OrganizationId,eos.UserDefaultPassword, eo.LicenseId, dco.CultureId AS DefaultCulture, eos.ElearningUrl, eos.FacebookLogin, eos.GoogleLogin,eos.PasswordReset,eos.Registration,
eos.LessonLength, eos.BackgroundColor,eos.TextColor,fr.Id AS BackgroundImage
 from Edu_OrganizationSetting as eos
join Edu_Organization  eo ON eos.OrganizationId = eo.Id and eo.IsDeleted =0 
left join Link_OrganizationCulture AS dco ON dco.OrganizationId = eo.Id AND dco.IsDeleted = 0 AND dco.IsDefault = 1
LEFT JOIN Edu_FileRepository AS fr ON eos.OrganizationId = fr.ObjectOwner AND fr.IsDeleted = 0
WHERE eos.IsDeleted= 0 AND eos.OrganizationId =@OrganizationId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Edu_OrganizationSetting",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
