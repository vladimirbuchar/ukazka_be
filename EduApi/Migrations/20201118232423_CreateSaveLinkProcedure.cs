using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateSaveLinkProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE SaveLink 
@EndTime datetime
,@UserId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @id uniqueidentifier 
SET @id = NEWID() 
INSERT INTO Edu_LinkLifeTime(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,IsActive,EndTime,UserId)
VALUES (@id, 0, 0, 1, null,1,@EndTime,@UserId);
SELECT @id AS OutGuid
 
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
