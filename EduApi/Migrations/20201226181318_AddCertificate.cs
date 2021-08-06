using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE AddCertificate 
@OrganizationId uniqueidentifier, 
@Name nvarchar(max),
@Html nvarchar(max)


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
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Html, OrganizationId, BasicInformationId) VALUES 
(@Edu_Certificate_id,0,0,1,null,@Html,@OrganizationId,@Edu_Basic_information_id)

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
