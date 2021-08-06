﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateBranchIsOnline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateBranch] 
@IsMainBranch bit 
,@OrganizationId uniqueidentifier 
,@ContactInformationEmail nvarchar(max) 
,@ContactInformationPhoneNumber nvarchar(max) 
,@ContactInformationWWW nvarchar(max) 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@AddressCountryId uniqueidentifier 
,@AddressRegion nvarchar(max) 
,@AddressCity nvarchar(max) 
,@AddressStreet nvarchar(max) 
,@AddressHouseNumber nvarchar(max) 
,@AddressZipCode nvarchar(max),
@IsOnline bit 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @Edu_Branch_id uniqueidentifier 
SET @Edu_Branch_id  = NEWID() 
DECLARE @ContactInformationId uniqueidentifier 
SET @ContactInformationId  = NEWID(); 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
DECLARE @AddressId uniqueidentifier 
SET @AddressId  = NEWID(); 
DECLARE @MaximumBranchLicense int;
SET @MaximumBranchLicense = (SELECT MaximumBranch FROM Cb_License WHERE Id = (SELECT LicenseId FROM Edu_Organization WHERE Id =@OrganizationId ))
DECLARE @BranchCount int;
SET @BranchCount = (SELECT COUNT(*) FROM Edu_Branch WHERE OrganizationId = @OrganizationId AND IsDeleted = 0)+1
if (@MaximumBranchLicense > 0 AND @BranchCount > @MaximumBranchLicense )
begin 
	
	RETURN 'Branch BranchCount > MaximumBranchLicense'
end


if @IsMainBranch =1
Begin
	UPDATE Edu_Branch SET IsMainBranch = 0 WHERE OrganizationId = @OrganizationId
End

INSERT INTO Shared_ContactInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Email,PhoneNumber,WWW) VALUES 
(@ContactInformationId,0,0,1,null,@ContactInformationEmail,@ContactInformationPhoneNumber,@ContactInformationWWW);

INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);

INSERT INTO Shared_Address (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId) VALUES 
(@AddressId,0,0,1,null,@AddressCountryId,@AddressRegion,@AddressCity,@AddressStreet,@AddressHouseNumber,@AddressZipCode,(SELECT Id FROM Cb_AddressType WHERE SystemIdentificator='BRANCH_ADDRESS') );

INSERT INTO Edu_Branch 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, IsMainBranch, OrganizationId, ContactInformationId, BasicInformationId, AddressId,IsOnline) VALUES 
(@Edu_Branch_id, 0, 0, 1, null, @IsMainBranch, @OrganizationId, @ContactInformationId, @BasicInformationId, @AddressId,@IsOnline); 

SELECT  @Edu_Branch_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateClassRoom] 
@Floor int 
,@BranchId uniqueidentifier 
,@MaxCapacity int 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max),
@IsOnline bit 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_ClassRoom_id uniqueidentifier 
SET @Edu_ClassRoom_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_ClassRoom 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Floor, BranchId, MaxCapacity, BasicInformationId,IsOnline) VALUES 
(@Edu_ClassRoom_id, 0, 0, 1, null, @Floor, @BranchId, @MaxCapacity, @BasicInformationId,@IsOnline); 
SELECT @Edu_ClassRoom_id AS OutGuid
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}