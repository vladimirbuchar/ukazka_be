using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentCourseAddCourseTermId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentCourse](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id, sbi.Name AS CourseName, ct.ActiveFrom, ct.ActiveTo,ttf.Value AS TimeFrom, ttt.Value AS TimeTo, lcs.UserId, csbi.Name AS ClassRoom, bsbi.Name AS  BranchName,
ct.Monday,ct.Thursday,ct.Wednesday,ct.Tuesday, ct.Friday, ct.Saturday, ct.Sunday,osbi.Name AS OrganizationName,ct.Id AS TermId
  FROM Edu_Course AS c
  JOIN Shared_BasicInformation as sbi ON sbi.Id = c.BasicInformationId  AND sbi.IsDeleted = 0
  JOIN Edu_CourseTerm AS ct ON ct.CourseId =  c.Id  and ct.IsDeleted = 0
  JOIN Cb_TimeTable AS ttf on  ct.TimeFromId = ttf.Id and ttf.IsDeleted = 0
  JOIN Cb_TimeTable AS ttt on  ct.TimeToId = ttt.Id and ttt.IsDeleted = 0
  JOIN Link_CourseStudent AS lcs ON lcs.CourseTermId = ct.Id and lcs.IsDeleted = 0
  JOIN Edu_ClassRoom AS cl ON ct.ClassRoomId = cl.Id AND cl.IsDeleted = 0
  JOIN Shared_BasicInformation AS  csbi ON csbi.Id = cl.BasicInformationId  AND csbi.IsDeleted = 0
  JOIN Edu_Branch AS eb ON cl.BranchId = eb.Id AND eb.IsDeleted = 0
  JOIN Shared_BasicInformation AS  bsbi ON bsbi.Id = eb.BasicInformationId AND bsbi.IsDeleted = 0
  JOIN Edu_Organization AS eo ON eb.OrganizationId = eo.Id AND eo.IsDeleted = 0
  JOIN Shared_BasicInformation AS  osbi ON osbi.Id = eo.BasicInformationId AND osbi.IsDeleted = 0
  JOIN Link_UserInOrganization AS uio ON lcs.UserId = uio.Id
  WHERE c.IsDeleted = 0  AND ct.ActiveTo >= SYSDATETIME() AND uio.UserId =@userId
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
