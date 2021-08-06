using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentTestChangeCourseIdToMaterialId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentTest](@userId uniqueidentifier )
RETURNS TABLE  AS
RETURN 
( 
SELECT sts.Id,  bi.Name, u.UserEmail, sts.Finish,sts.Score,sts.TestCompleted, ct.Id AS TestId, cl.CourseMaterialId 
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

        }
    }
}
