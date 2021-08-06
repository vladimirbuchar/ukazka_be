using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateOnlineBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @OrgId uniqueidentifier
DECLARE @DefaultCountry uniqueidentifier
SET @DefaultCountry = (SELECT Id FROM Cb_Country WHERE IsDefault = 1)

DECLARE ORG_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_Organization WHERE IsDeleted = 0

OPEN ORG_CURSOR
FETCH NEXT FROM ORG_CURSOR INTO @OrgId
WHILE @@FETCH_STATUS = 0
BEGIN 
	
    EXEC CreateBranch @IsMainBranch=0,@OrganizationId =@OrgId,@ContactInformationEmail='',@ContactInformationPhoneNumber='',
	@ContactInformationWWW ='',@BasicInformationName='ONLINE_BRANCH',@BasicInformationDescription='',@AddressCountryId = @DefaultCountry,
	@AddressRegion = '',@AddressCity= '',@AddressStreet='',@AddressHouseNumber= '',@AddressZipCode = '',@IsOnline =1

    FETCH NEXT FROM ORG_CURSOR INTO @OrgId
END
CLOSE ORG_CURSOR
DEALLOCATE ORG_CURSOR");

            migrationBuilder.Sql(@"DECLARE @branchId uniqueidentifier

DECLARE BRANCH_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_Branch WHERE IsDeleted = 0 AND IsOnline = 0

OPEN BRANCH_CURSOR
FETCH NEXT FROM BRANCH_CURSOR INTO @branchId
WHILE @@FETCH_STATUS = 0
BEGIN 
	EXEC CreateClassRoom @Floor = 0, @BranchId = @branchId, @MaxCapacity = 0,@BasicInformationName = 'ONLINE_CLASSROOM',  @BasicInformationDescription ='',@IsOnline =1
  

    FETCH NEXT FROM BRANCH_CURSOR INTO @branchId
END
CLOSE BRANCH_CURSOR
DEALLOCATE BRANCH_CURSOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
