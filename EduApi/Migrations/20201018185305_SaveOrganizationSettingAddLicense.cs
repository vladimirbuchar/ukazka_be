using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveOrganizationSettingAddLicense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveOrganizationSetting] 
@OrganizationId uniqueidentifier 
,@UserDefaultPassword varchar(max),
@LicenseId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE  Edu_OrganizationSetting SET
UserDefaultPassword = @UserDefaultPassword,
LicenseChange= SYSDATETIME(),
LicenseOldId = (SELECT Top(1) LicenseId FROM Edu_Organization WHERE Id =@OrganizationId AND IsDeleted =0)
WHERE OrganizationId = @OrganizationId

Update Edu_Organization SET LicenseId = @LicenseId
 
WHERE Id = @OrganizationId

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
