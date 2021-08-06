using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetNewPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE SetNewPassword 
@LinkId uniqueidentifier ,
@Password nvarchar(max) 


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @userId  uniqueidentifier 
SET @userId = (SELECT UserId FROM Edu_LinkLifeTime
WHERE Id = @LinkId AND IsDeleted = 0 AND EndTime  >=SYSDATETIME()) 
UPDATE Edu_User SET UserPassword =@Password WHERE Id =@userId

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
