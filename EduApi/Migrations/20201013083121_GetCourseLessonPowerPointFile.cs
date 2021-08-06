using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseLessonPowerPointFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  FUNCTION GetCourseLessonPowerPointFile(@CourseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cl.Id,  sbi.Name, sbi.Description, cl.PowerPointFile
				  FROM Edu_CourseLesson AS cl
				  LEFT JOIN Edu_FileRepository AS fr ON cl.Id = fr.ObjectOwner AND fr.IsDeleted = 0
                  JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
				 
                  WHERE cl.Id = @CourseLessonId AND cl.IsDeleted = 0
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
