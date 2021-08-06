using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddNoteChangeCourseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Note_Edu_CourseLessonItem_CourseLessonItemId",
                table: "Edu_Note");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Note_CourseLessonItemId",
                table: "Edu_Note");

            migrationBuilder.DropColumn(
                name: "CourseLessonItemId",
                table: "Edu_Note");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Edu_Note",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_CourseId",
                table: "Edu_Note",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Note_Edu_Course_CourseId",
                table: "Edu_Note",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[AddNote] 
@courseLessonItemId uniqueidentifier 
,@noteType uniqueidentifier ,
@text nvarchar(max),
@userId uniqueidentifier,
@noteName nvarchar(max),
@fileName nvarchar(max)


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 




INSERT INTO Edu_Note 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,IsActive, Text, CourseId, NoteTypeId,UserId,NoteName,FileName) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, 1, @text,@courseLessonItemId,@noteType,@userId,@noteName,@fileName); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

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
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Note_Edu_Course_CourseId",
                table: "Edu_Note");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Note_CourseId",
                table: "Edu_Note");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Edu_Note");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseLessonItemId",
                table: "Edu_Note",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_CourseLessonItemId",
                table: "Edu_Note",
                column: "CourseLessonItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Note_Edu_CourseLessonItem_CourseLessonItemId",
                table: "Edu_Note",
                column: "CourseLessonItemId",
                principalTable: "Edu_CourseLessonItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
