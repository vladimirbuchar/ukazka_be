using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeOnlineClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @branchId uniqueidentifier
UPDATE Edu_ClassRoom SET IsDeleted = 1 WHERE IsOnline = 1

DECLARE BRANCH_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_Branch WHERE IsDeleted = 0 AND IsOnline = 1

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
