using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCourseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE UpdateCourseTest
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
 UPDATE Edu_CourseTest SET IsRandomGenerateQuestion = @IsRandomGenerateQuestion, QuestionCountInTest =@QuestionCountInTest,TimeLimit=@TimeLimit,DesiredSuccess =@DesiredSuccess 
 WHERE CourseLessonId =@CourseLessonId


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
