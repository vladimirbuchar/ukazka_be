using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddSetGoogleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE [dbo].[SetGoogleId] 
@GoogleId nvarchar(max)
, @UserId uniqueidentifier

AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION


UPDATE Edu_User SET GoogleId = @GoogleId
WHERE Id = @UserId


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
