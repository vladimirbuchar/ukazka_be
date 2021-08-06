using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GoogleApiToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleApiToken",
                table: "Edu_OrganizationSetting",
                nullable: true);
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveOrganizationSetting] 
@OrganizationId uniqueidentifier 
,@UserDefaultPassword varchar(max),
@LicenseId uniqueidentifier,
@DefaultCulture uniqueidentifier,
@UrlElearning varchar(max),
@FacebookLogin bit, 
@GoogleLogin bit,
@PasswordReset bit,
@Registration bit,
@LessonLength int,
@BackgroundColor varchar(max),
@TextColor varchar(max),

@UseCustomSmtpServer bit,
@SmtpServerPassword varchar(max),
@SmtpServerPort varchar(max),
@SmtpServerUrl varchar(max),
@SmtpServerUserName varchar(max),
@GoogleApiToken varchar(max)
AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE  Edu_OrganizationSetting SET
UserDefaultPassword = @UserDefaultPassword,
LicenseChange= SYSDATETIME(),
LicenseOldId = (SELECT Top(1) LicenseId FROM Edu_Organization WHERE Id =@OrganizationId AND IsDeleted =0),
ElearningUrl =@UrlElearning,
FacebookLogin =@FacebookLogin,
GoogleLogin =@GoogleLogin,
PasswordReset =@PasswordReset,
Registration =@Registration,
LessonLength =@LessonLength,
BackgroundColor =@BackgroundColor,
TextColor =@TextColor,
UseCustomSmtpServer =@UseCustomSmtpServer,
SmtpServerPassword =@SmtpServerPassword,
SmtpServerPort =@SmtpServerPort,
SmtpServerUrl =@SmtpServerUrl,
SmtpServerUserName =@SmtpServerUserName,
GoogleApiToken =@GoogleApiToken

WHERE OrganizationId = @OrganizationId

Update Edu_Organization SET LicenseId = @LicenseId
WHERE Id = @OrganizationId

declare @count int;
set @count = (SELECT COUNT(*) FROM Link_OrganizationCulture WHERE OrganizationId = @OrganizationId AND IsDefault = 1 AND IsDeleted = 0);
if @count = 0
begin 
INSERT INTO Link_OrganizationCulture (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,OrganizationId,CultureId,IsDefault) VALUES 
(NEWID(),0,0,1,null,1,@OrganizationId,@DefaultCulture,1)
end

UPDATE Link_OrganizationCulture SET CultureId =@DefaultCulture WHERE OrganizationId = @OrganizationId AND IsDefault = 1 AND IsDeleted = 0


COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSetting](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eos.OrganizationId,eos.UserDefaultPassword, eo.LicenseId, dco.CultureId AS DefaultCulture, eos.ElearningUrl, eos.FacebookLogin, eos.GoogleLogin,eos.PasswordReset,eos.Registration,
eos.LessonLength, eos.BackgroundColor,eos.TextColor,fr.Id AS BackgroundImage,fr.FileName,fr.OriginalFileName, UseCustomSmtpServer,SmtpServerPassword,SmtpServerPort,SmtpServerUrl,SmtpServerUserName,
eos.GoogleApiToken
 from Edu_OrganizationSetting as eos
join Edu_Organization  eo ON eos.OrganizationId = eo.Id and eo.IsDeleted =0 
left join Link_OrganizationCulture AS dco ON dco.OrganizationId = eo.Id AND dco.IsDeleted = 0 AND dco.IsDefault = 1
LEFT JOIN Edu_FileRepository AS fr ON eos.OrganizationId = fr.ObjectOwner AND fr.IsDeleted = 0
WHERE eos.IsDeleted= 0 AND eos.OrganizationId =@OrganizationId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleApiToken",
                table: "Edu_OrganizationSetting");
        }
    }
}
