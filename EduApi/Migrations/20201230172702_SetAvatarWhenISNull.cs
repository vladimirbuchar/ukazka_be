using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetAvatarWhenISNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[SetFacebookId] 
@FacebookId nvarchar(max) 
,@UserId uniqueidentifier,
@AvatarUrl nvarchar(max)

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION


UPDATE Edu_User SET FacebookId = @FacebookId
WHERE Id = @UserId

UPDATE Edu_Person SET AvatarUrl =@AvatarUrl WHERE Id = (SELECT TOP(1) PersonId FROM Edu_User WHERE Id =@UserId)  AND AvatarUrl = NULL
 
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[SetGoogleId] 
@GoogleId nvarchar(max)
, @UserId uniqueidentifier,
@AvatarUrl nvarchar(max)

AS
BEGIN
SET NOCOUNT ON;
            BEGIN TRY
BEGIN TRANSACTION


UPDATE Edu_User SET GoogleId = @GoogleId
WHERE Id = @UserId

UPDATE Edu_Person SET AvatarUrl =@AvatarUrl WHERE Id = (SELECT TOP(1) PersonId FROM Edu_User WHERE Id =@UserId) AND AvatarUrl = NULL


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
