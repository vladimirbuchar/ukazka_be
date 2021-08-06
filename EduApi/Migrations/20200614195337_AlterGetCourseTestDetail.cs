using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AlterGetCourseTestDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseTestDetail](@courseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cl.Id, sbi.Name, sbi.Description, t.IsRandomGenerateQuestion,t.QuestionCountInTest,t.TimeLimit, t.DesiredSuccess, t.Id AS TestId FROM Edu_CourseLesson AS cl
                                           JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId =  sbi.Id AND sbi.IsDeleted = 0
										   JOIN Edu_CourseTest AS t on cl.Id = t.CourseLessonId AND t.IsDeleted = 0
WHERE cl.Id =@courseLessonId AND cl.IsDeleted = 0)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
