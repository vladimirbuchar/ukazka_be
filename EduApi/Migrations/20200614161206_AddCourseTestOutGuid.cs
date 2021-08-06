using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseTestOutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddCourseTest] 
@IsRandomGenerateQuestion bit 
,@QuestionCountInTest int 
,@TimeLimit int 
,@DesiredSuccess int 
,@CourseLessonId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseTest_id uniqueidentifier 
SET @Edu_CourseTest_id  = NEWID() 
INSERT INTO Edu_CourseTest 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, IsRandomGenerateQuestion, QuestionCountInTest, TimeLimit, DesiredSuccess, CourseLessonId) VALUES 
(@Edu_CourseTest_id, 0, 0, 1, null, @IsRandomGenerateQuestion, @QuestionCountInTest, @TimeLimit, @DesiredSuccess, @CourseLessonId); 
SELECT @Edu_CourseTest_id AS OutGuid

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
