using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateNoteAddFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateNote] 
@noteId uniqueidentifier,
@text nvarchar(max),
@noteName nvarchar(max),
@fileName nvarchar(max)



AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
 UPDATE Edu_Note SET
 Text = @text,
 NoteName = @noteName,
 FileName = @fileName
 WHERE Id =@noteId

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
