using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCertificateSaveValidateTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddCertificate] 
@OrganizationId uniqueidentifier, 
@Name nvarchar(max),
@Html nvarchar(max),
@CertificateValidTo int


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


INSERT INTO Edu_Certificate 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Html, OrganizationId, BasicInformationId,CertificateValidTo) VALUES 
(@Edu_Certificate_id,0,0,1,null,@Html,@OrganizationId,@Edu_Basic_information_id,@CertificateValidTo)

SELECT @Edu_Certificate_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateCertificate] 
@Id uniqueidentifier, 
@Name nvarchar(max),
@Html nvarchar(max),
@CertificateValidTo int


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Sbi uniqueidentifier;
SET @Sbi =(SELECT BasicInformationId FROM Edu_Certificate WHERE Id = @Id AND IsDeleted = 0)

UPDATE Shared_BasicInformation SET Name =@Name WHERE Id =@Sbi
UPDATE Edu_Certificate SET Html =@Html,
CertificateValidTo =@CertificateValidTo
WHERE Id =@Id;

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCertificateInOrganization] (@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ec.Id,Html, sbi.Name,ec.CertificateValidTo FROM Edu_Certificate AS	ec
JOIN Shared_BasicInformation AS sbi ON ec.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE ec.OrganizationId = @OrganizationId AND ec.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
