using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllStudentTestResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetAllStudentTestResult](@courseId uniqueidentifier )
RETURNS TABLE  AS
RETURN 
( 
SELECT sts.Id, p.FirstName, p.SecondName, p.LastName, bi.Name, u.UserEmail
  FROM Edu_StudentTestSummary as sts
  JOIN Edu_CourseTest AS ct ON sts.CourseTestId = ct.Id AND ct.IsDeleted = 0
  JOIN Edu_CourseLesson AS cl ON cl.Id = ct.CourseLessonId AND cl.IsDeleted =0
  JOIN Edu_User AS u ON u.Id = sts.UserId AND u.IsDeleted = 0 
  JOIN Edu_Person AS p ON p.Id = u.PersonId AND p.IsDeleted = 0
  JOIN Shared_BasicInformation AS bi ON bi.Id = cl.BasicInformationId AND bi.IsDeleted = 0
  JOIN Link_UserInOrganization AS uio ON uio.UserId = sts.UserId AND uio.IsDeleted = 0
  JOIN Edu_OrganizationRole AS eor ON uio.OrganizationRoleId = eor.Id AND eor.IsDeleted = 0
  WHERE cl.CourseId = @courseId AND  sts.IsDeleted = 0 AND eor.SystemIdentificator ='STUDENT' 
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
