using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE [dbo].UpdateNote 
@noteId uniqueidentifier,
@text nvarchar(max)



AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
 UPDATE Edu_Note SET
 Text = @text
 WHERE Id =@noteId

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
