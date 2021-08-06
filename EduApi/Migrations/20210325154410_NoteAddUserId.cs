using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class NoteAddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Edu_Note",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_UserId",
                table: "Edu_Note",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Note_Edu_User_UserId",
                table: "Edu_Note",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].AddNote 
@courseLessonItemId uniqueidentifier 
,@noteType uniqueidentifier ,
@text nvarchar(max),
@userId uniqueidentifier


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 




INSERT INTO Edu_Note 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Text, CourseLessonItemId, NoteTypeId,UserId) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, @text,@courseLessonItemId,@noteType,@userId); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Note_Edu_User_UserId",
                table: "Edu_Note");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Note_UserId",
                table: "Edu_Note");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Edu_Note");
        }
    }
}
