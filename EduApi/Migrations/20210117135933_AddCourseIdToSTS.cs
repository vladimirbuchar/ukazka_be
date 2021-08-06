using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCourseIdToSTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Edu_StudentTestSummary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_StudentTestSummary_CourseId",
                table: "Edu_StudentTestSummary",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentTestSummary_Edu_Course_CourseId",
                table: "Edu_StudentTestSummary",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[StartTest] 
@StartTime datetime 
,@UserId uniqueidentifier 
,@Finish datetime 
,@TestCompleted bit 
,@CourseTestId uniqueidentifier 
,@CourseId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_StudentTestSummary_id uniqueidentifier 
SET @Edu_StudentTestSummary_id  = NEWID() 
INSERT INTO Edu_StudentTestSummary 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, StartTime, UserId, Finish, TestCompleted, CourseTestId,Score,CourseId) VALUES 
(@Edu_StudentTestSummary_id, 0, 0, 1, null, @StartTime, @UserId, @Finish, @TestCompleted, @CourseTestId,0,@CourseId); 
SELECT @Edu_StudentTestSummary_id AS OutGuid
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentTest](@userId uniqueidentifier )
RETURNS TABLE  AS
RETURN 
( 
SELECT sts.Id,  bi.Name, u.UserEmail, sts.Finish,sts.Score,sts.TestCompleted, ct.Id AS TestId, cl.CourseMaterialId, sts.CourseId
  FROM Edu_StudentTestSummary as sts
  LEFT JOIN Edu_CourseTest AS ct ON sts.CourseTestId = ct.Id AND ct.IsDeleted = 0
  LEFT JOIN Edu_CourseLesson AS cl ON cl.Id = ct.CourseLessonId AND cl.IsDeleted =0
  JOIN Edu_User AS u ON u.Id = sts.UserId AND u.IsDeleted = 0 
  JOIN Shared_BasicInformation AS bi ON bi.Id = cl.BasicInformationId AND bi.IsDeleted = 0
  WHERE u.Id = @userId 
  )
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentTestSummary_Edu_Course_CourseId",
                table: "Edu_StudentTestSummary");

            migrationBuilder.DropIndex(
                name: "IX_Edu_StudentTestSummary_CourseId",
                table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Edu_StudentTestSummary");
        }
    }
}
