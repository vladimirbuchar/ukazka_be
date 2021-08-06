using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateDefaultBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @OrgId uniqueidentifier

DECLARE ORG_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_Organization WHERE IsDeleted = 0

OPEN ORG_CURSOR
FETCH NEXT FROM ORG_CURSOR INTO @OrgId
WHILE @@FETCH_STATUS = 0
BEGIN 
    EXEC CreateBankOfQuestion @OrganizationId =  @OrgId, @BasicInformationName='DEFAULT_BANK_OF_QUESTION',@BasicInformationDescription='',@IsDefault =1
    FETCH NEXT FROM ORG_CURSOR INTO @OrgId
END
CLOSE ORG_CURSOR
DEALLOCATE ORG_CURSOR
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
