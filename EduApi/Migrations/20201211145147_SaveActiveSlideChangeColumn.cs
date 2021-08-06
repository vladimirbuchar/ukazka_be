using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveActiveSlideChangeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[SaveActiveSlide]


@slideId uniqueidentifier,
@userId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @courseId uniqueidentifier 
DECLARE @count int
DECLARE @editId uniqueidentifier 

SET @courseId = (SELECT TOP(1) ecl.CourseId FROM  Edu_CourseLessonItem as ecli 
JOIN Edu_CourseLesson AS ecl ON ecl.Id = ecli.CourseLessonId
WHERE ecli.Id = @slideId)
SET @count = (SELECT COUNT(*) FROM Link_CouseStudentMaterial WHERE UserId = @userId AND CourseId =@courseId AND IsDeleted = 0)
SET @editId = (SELECT Id FROM Link_CouseStudentMaterial WHERE UserId = @userId AND CourseId =@courseId AND IsDeleted = 0)
if (@count = 0) BEGIN
INSERT INTO Link_CouseStudentMaterial 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,UserId,CourseLessonItem,CourseId)
VALUES
(NEWID(),0, 0, 1, null, @userId,@slideId,@courseId);
END
else begin
Update Link_CouseStudentMaterial set CourseLessonItem =@slideId WHERE Id =@editId
end



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
