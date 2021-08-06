using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetClassRoomTimeTableAleer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION GetClassRoomTimeTable (@classRoomId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id, sbi.Name AS CourseName, ttf.Value AS TimeFrom, ttt.Value AS TimeTo ,ct.Monday,ct.Thursday,ct.Wednesday,ct.Tuesday, ct.Friday, ct.Saturday, ct.Sunday,
ct.TimeFromId,ct.TimeToId
  FROM Edu_Course AS c
  JOIN Shared_BasicInformation as sbi ON sbi.Id = c.BasicInformationId  AND sbi.IsDeleted = 0
  JOIN Edu_CourseTerm AS ct ON ct.CourseId =  c.Id  and ct.IsDeleted = 0
	JOIN Cb_TimeTable AS ttf on  ct.TimeFromId = ttf.Id and ttf.IsDeleted = 0
 JOIN Cb_TimeTable AS ttt on  ct.TimeToId = ttt.Id and ttt.IsDeleted = 0
  JOIN Edu_ClassRoom AS cl ON ct.ClassRoomId = cl.Id AND cl.IsDeleted = 0
  WHERE cl.Id=@classRoomId AND c.IsDeleted = 0  AND SYSDATETIME() <= ct.ActiveTo 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
