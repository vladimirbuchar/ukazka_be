using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateBranchLicenceNotOnline : Migration
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
SET @BranchCount = (SELECT COUNT(*) FROM Edu_Branch WHERE OrganizationId = @OrganizationId AND IsDeleted = 0 AND IsOnline = 0)+1
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
END");

            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateOrganization]
                         @CanSendCourseInquiry bit 
                        ,@ContactInformationEmail nvarchar(max) 
                        ,@ContactInformationPhoneNumber nvarchar(max) 
                        ,@ContactInformationWWW nvarchar(max) 
                        ,@BasicInformationName nvarchar(max) 
                        ,@BasicInformationDescription nvarchar(max) 
                        ,@UserId uniqueidentifier 
                        ,@OrganizationRoleIdentificator nvarchar(max) 
                        ,@LicenseIdentificator nvarchar(max),
						
						@addressCountry  uniqueidentifier,
						@addressRegion nvarchar(max),
						@addressCity nvarchar(max),
						@addressStreet nvarchar(max),
						@addressHouseNumber nvarchar(max),
						@addressZipCode nvarchar(max),
						@addressTypeId uniqueidentifier,

						@addressCountryContact  uniqueidentifier,
						@addressRegionContact nvarchar(max),
						@addressCityContact nvarchar(max),
						@addressStreetContact nvarchar(max),
						@addressHouseNumberContact nvarchar(max),
						@addressZipCodeContact nvarchar(max),
						@addressTypeIdContact uniqueidentifier,
						@DefaultPassword nvarchar(max)


                        AS 
                        BEGIN 
                            SET NOCOUNT ON; 
                            BEGIN TRY
                                BEGIN TRANSACTION
                                    DECLARE @Edu_Organization_id uniqueidentifier 
                                    SET @Edu_Organization_id  = NEWID() 
                                    DECLARE @ContactInformationId uniqueidentifier 
                                    SET @ContactInformationId  = NEWID(); 
                                    DECLARE @LicenseSendCourseInquiry bit
                                    SET @LicenseSendCourseInquiry = (SELECT SendCourseInquiry FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @BasicInformationId uniqueidentifier 
                                    SET @BasicInformationId  = NEWID(); 
                                    DECLARE @OrganizationRoleId uniqueidentifier
                                    SET @OrganizationRoleId = (SELECT Id FROM Edu_OrganizationRole WHERE SystemIdentificator = @OrganizationRoleIdentificator AND IsDeleted = 0) 
                                    DECLARE @LicenseId uniqueidentifier
                                    SET @LicenseId = (SELECT Id FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @CanSendCourseInquiry_tmp bit;
                                    SET @CanSendCourseInquiry_tmp = @CanSendCourseInquiry


                                    IF @CanSendCourseInquiry = 1 AND @LicenseSendCourseInquiry = 0
                                    begin
                                    SET @CanSendCourseInquiry_tmp = 0
                                    End

                                    INSERT INTO Shared_ContactInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Email,PhoneNumber,WWW) VALUES 
                                    (@ContactInformationId,0,0,1,null,@ContactInformationEmail,@ContactInformationPhoneNumber,@ContactInformationWWW);


                                    INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
                                    (@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);

                                    INSERT INTO Edu_Organization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CanSendCourseInquiry, ContactInformationId, BasicInformationId,LicenseId) VALUES 
                                    (@Edu_Organization_id, 0, 0, 1, null, @CanSendCourseInquiry_tmp, @ContactInformationId, @BasicInformationId,@LicenseId); 

                                    INSERT INTO Link_UserInOrganization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, OrganizationId, OrganizationRoleId, UserId) VALUES 
                                    (NEWID(), 0, 0, 1, null, @Edu_Organization_id, @OrganizationRoleId, @UserId); 

									INSERT INTO Shared_Address 
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,OrganizationId)
									VALUES 
									(NEWID(),0,1,0,null,@addressCountry,@addressRegion,@addressCity,@addressStreet,@addressHouseNumber,@addressZipCode,@addressTypeId,@Edu_Organization_id);

									INSERT INTO Shared_Address 
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,OrganizationId)
									VALUES 
									(NEWID(),0,1,0,null,@addressCountryContact,@addressRegionContact,@addressCityContact,@addressStreetContact,@addressHouseNumberContact,@addressZipCodeContact,@addressTypeIdContact,@Edu_Organization_id);
									
									INSERT INTO Edu_OrganizationSetting
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,OrganizationId,UserDefaultPassword)
									VALUES
									(NEWID(),0,1,0,null,@Edu_Organization_id,@DefaultPassword)

									DECLARE @countryId uniqueidentifier;
									set @countryId = (SELECT  TOP(1) Id FROM Cb_Country WHERE IsDefault = 1);
									EXEC CreateBankOfQuestion @OrganizationId =  @Edu_Organization_id, @BasicInformationName='DEFAULT_BANK_OF_QUESTION',@BasicInformationDescription='',@IsDefault =1
									EXEC CreateBranch @IsMainBranch = 0, @OrganizationId = @Edu_Organization_id, @ContactInformationEmail= '', @ContactInformationPhoneNumber= '', @ContactInformationWWW = '',
									@BasicInformationName ='',@BasicInformationDescription = '',@AddressCountryId = @countryId, @AddressRegion ='', @AddressCity='',@AddressStreet = '',@AddressHouseNumber ='',
									@AddressZipCode = '',@IsOnline =1 

									SELECT @Edu_Organization_id AS OutGuid


                                COMMIT
                            END TRY
                            BEGIN CATCH
                                ROLLBACK
                            END CATCH
                        END ");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateOrganization]
                         @CanSendCourseInquiry bit 
                        ,@ContactInformationEmail nvarchar(max) 
                        ,@ContactInformationPhoneNumber nvarchar(max) 
                        ,@ContactInformationWWW nvarchar(max) 
                        ,@BasicInformationName nvarchar(max) 
                        ,@BasicInformationDescription nvarchar(max) 
                        ,@UserId uniqueidentifier 
                        ,@OrganizationRoleIdentificator nvarchar(max) 
                        ,@LicenseIdentificator nvarchar(max),
						
						@addressCountry  uniqueidentifier,
						@addressRegion nvarchar(max),
						@addressCity nvarchar(max),
						@addressStreet nvarchar(max),
						@addressHouseNumber nvarchar(max),
						@addressZipCode nvarchar(max),
						@addressTypeId uniqueidentifier,

						@addressCountryContact  uniqueidentifier,
						@addressRegionContact nvarchar(max),
						@addressCityContact nvarchar(max),
						@addressStreetContact nvarchar(max),
						@addressHouseNumberContact nvarchar(max),
						@addressZipCodeContact nvarchar(max),
						@addressTypeIdContact uniqueidentifier,
						@DefaultPassword nvarchar(max)


                        AS 
                        BEGIN 
                            SET NOCOUNT ON; 
                            BEGIN TRY
                                BEGIN TRANSACTION
                                    DECLARE @Edu_Organization_id uniqueidentifier 
                                    SET @Edu_Organization_id  = NEWID() 
                                    DECLARE @ContactInformationId uniqueidentifier 
                                    SET @ContactInformationId  = NEWID(); 
                                    DECLARE @LicenseSendCourseInquiry bit
                                    SET @LicenseSendCourseInquiry = (SELECT SendCourseInquiry FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @BasicInformationId uniqueidentifier 
                                    SET @BasicInformationId  = NEWID(); 
                                    DECLARE @OrganizationRoleId uniqueidentifier
                                    SET @OrganizationRoleId = (SELECT Id FROM Edu_OrganizationRole WHERE SystemIdentificator = @OrganizationRoleIdentificator AND IsDeleted = 0) 
                                    DECLARE @LicenseId uniqueidentifier
                                    SET @LicenseId = (SELECT Id FROM Cb_License WHERE SystemIdentificator = @LicenseIdentificator AND IsDeleted = 0) 
                                    DECLARE @CanSendCourseInquiry_tmp bit;
                                    SET @CanSendCourseInquiry_tmp = @CanSendCourseInquiry


                                    IF @CanSendCourseInquiry = 1 AND @LicenseSendCourseInquiry = 0
                                    begin
                                    SET @CanSendCourseInquiry_tmp = 0
                                    End

                                    INSERT INTO Shared_ContactInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Email,PhoneNumber,WWW) VALUES 
                                    (@ContactInformationId,0,0,1,null,@ContactInformationEmail,@ContactInformationPhoneNumber,@ContactInformationWWW);


                                    INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
                                    (@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);

                                    INSERT INTO Edu_Organization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CanSendCourseInquiry, ContactInformationId, BasicInformationId,LicenseId) VALUES 
                                    (@Edu_Organization_id, 0, 0, 1, null, @CanSendCourseInquiry_tmp, @ContactInformationId, @BasicInformationId,@LicenseId); 

                                    INSERT INTO Link_UserInOrganization 
                                    (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, OrganizationId, OrganizationRoleId, UserId) VALUES 
                                    (NEWID(), 0, 0, 1, null, @Edu_Organization_id, @OrganizationRoleId, @UserId); 

									INSERT INTO Shared_Address 
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,OrganizationId)
									VALUES 
									(NEWID(),0,1,0,null,@addressCountry,@addressRegion,@addressCity,@addressStreet,@addressHouseNumber,@addressZipCode,@addressTypeId,@Edu_Organization_id);

									INSERT INTO Shared_Address 
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId,OrganizationId)
									VALUES 
									(NEWID(),0,1,0,null,@addressCountryContact,@addressRegionContact,@addressCityContact,@addressStreetContact,@addressHouseNumberContact,@addressZipCodeContact,@addressTypeIdContact,@Edu_Organization_id);
									
									INSERT INTO Edu_OrganizationSetting
									(Id,IsDeleted,IsChanged,IsSystemObject, SystemIdentificator,OrganizationId,UserDefaultPassword)
									VALUES
									(NEWID(),0,1,0,null,@Edu_Organization_id,@DefaultPassword)

									DECLARE @countryId uniqueidentifier;
									set @countryId = (SELECT  TOP(1) Id FROM Cb_Country WHERE IsDefault = 1);
									EXEC CreateBankOfQuestion @OrganizationId =  @Edu_Organization_id, @BasicInformationName='DEFAULT_BANK_OF_QUESTION',@BasicInformationDescription='',@IsDefault =1
									EXEC CreateBranch @IsMainBranch = 0, @OrganizationId = @Edu_Organization_id, @ContactInformationEmail= '', @ContactInformationPhoneNumber= '', @ContactInformationWWW = '',
									@BasicInformationName ='ONLINE_BRANCH',@BasicInformationDescription = '',@AddressCountryId = @countryId, @AddressRegion ='', @AddressCity='',@AddressStreet = '',@AddressHouseNumber ='',
									@AddressZipCode = '',@IsOnline =1 

									SELECT @Edu_Organization_id AS OutGuid


                                COMMIT
                            END TRY
                            BEGIN CATCH
                                ROLLBACK
                            END CATCH
                        END ");
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
if (@IsOnline = 1)
EXEC CreateClassRoom @Floor= 0, @BranchId =@BranchId,@MaxCapacity =0, @BasicInformationName='ONLINE_CLASSROOM', @BasicInformationDescription='',@IsOnline =1
SELECT @Edu_ClassRoom_id AS OutGuid
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
