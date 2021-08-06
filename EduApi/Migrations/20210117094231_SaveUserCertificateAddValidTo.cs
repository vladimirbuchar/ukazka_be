using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveUserCertificateAddValidTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveUserCertificate]
@userId uniqueidentifier, 
@name nvarchar(max),
@fileName nvarchar(max),
@certificateValidTo datetime


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_Certificate_id uniqueidentifier 
SET @Edu_Certificate_id  = NEWID() 

DECLARE @Edu_Basic_information_id uniqueidentifier 
SET @Edu_Basic_information_id  = NEWID() 

INSERT INTO Shared_BasicInformation  (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Description,IsActive) VALUES
(@Edu_Basic_information_id,0,0,1,null,@Name,'',1)


INSERT INTO Edu_UserCertificate 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,IsActive, UserId, BasicInformationId,ActiveFrom,FileName,ValidTo) VALUES 
(@Edu_Certificate_id,0,0,1,null,1,@userId,@Edu_Basic_information_id,SYSDATETIME(),@fileName,@certificateValidTo)

SELECT @Edu_Certificate_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
