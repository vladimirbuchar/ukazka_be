using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudyHourProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE [dbo].AddStudyHour 
@OrganizationId uniqueidentifier,
@ActiveFromId uniqueidentifier,
@ActiveToId uniqueidentifier,
@Position int


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_id uniqueidentifier 
SET @Edu_id = NEWID() 



INSERT INTO Edu_OrganizationStudyHour 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, IsActive, Position, ActiveFromId,ActiveToId,OrganizationId) VALUES 
(@Edu_id, 0, 0, 1, null,1,@Position,@ActiveFromId,@ActiveToId, @OrganizationId)
SELECT @Edu_id AS OutGuid

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
