using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveOrganizationSettingCultureSaveWhneDonotExist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveOrganizationSetting] 
@OrganizationId uniqueidentifier 
,@UserDefaultPassword varchar(max),
@LicenseId uniqueidentifier,
@DefaultCulture uniqueidentifier

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

declare @count int;
set @count = (SELECT COUNT(*) FROM Link_OrganizationCulture WHERE OrganizationId = @OrganizationId AND IsDefault = 1);
if @count = 0
begin 
INSERT INTO Link_OrganizationCulture (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,OrganizationId,CultureId,IsDefault) VALUES 
(NEWID(),0,0,1,null,1,@OrganizationId,@DefaultCulture,1)
end

UPDATE Link_OrganizationCulture SET CultureId =@DefaultCulture WHERE OrganizationId = @OrganizationId AND IsDefault = 1


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
