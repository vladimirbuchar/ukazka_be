using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddNoteNmaeToNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteName",
                table: "Edu_Note",
                nullable: true);
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[AddNote] 
@courseLessonItemId uniqueidentifier 
,@noteType uniqueidentifier ,
@text nvarchar(max),
@userId uniqueidentifier,
@noteName nvarchar(max)


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 




INSERT INTO Edu_Note 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,IsActive, Text, CourseLessonItemId, NoteTypeId,UserId,NoteName) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, 1, @text,@courseLessonItemId,@noteType,@userId,@noteName); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateNote] 
@noteId uniqueidentifier,
@text nvarchar(max),
@noteName nvarchar(max)



AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
 UPDATE Edu_Note SET
 Text = @text,
 NoteName = @noteName
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
            migrationBuilder.DropColumn(
                name: "NoteName",
                table: "Edu_Note");
        }
    }
}
