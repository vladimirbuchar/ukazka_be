using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudyHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStudyHours (@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT osh.Id,osh.Position,osh.ActiveFromId,osh.ActiveToId, osh.OrganizationId, ttf.Value AS ActiveFrom, ttt.Value AS ActiveTo FROM Edu_OrganizationStudyHour AS osh
JOIN Cb_TimeTable AS ttf ON osh.ActiveFromId =ttf.Id AND ttf.IsDeleted = 0
JOIN Cb_TimeTable AS ttt ON osh.ActiveToId =ttt.Id AND ttt.IsDeleted = 0
WHERE osh.OrganizationId = @organizationId AND  osh.IsDeleted = 0 

                           
)
 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
