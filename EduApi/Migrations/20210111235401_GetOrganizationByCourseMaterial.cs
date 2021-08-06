using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCourseMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetOrganizationByCourseMaterial (@courseMaterialId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_CourseMaterial AS cm ON o.Id = cm.OrganizationId AND cm.IsDeleted = 0
                   WHERE cm.Id = @courseMaterialId  AND o.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
