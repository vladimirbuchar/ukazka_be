using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveOrganizationSettingToUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveOrganizationSetting] 
@OrganizationId uniqueidentifier 
,@UserDefaultPassword varchar(max)

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE  Edu_OrganizationSetting SET
UserDefaultPassword = @UserDefaultPassword
WHERE OrganizationId = @OrganizationId

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
