using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByStudentGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetOrganizationByStudentGroupId (@studentGroupId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_StudentGroup AS sg ON o.Id = sg.OrganizationId AND sg.IsDeleted = 0
                   WHERE sg.Id = @studentGroupId  AND o.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
