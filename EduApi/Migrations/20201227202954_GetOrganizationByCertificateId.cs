using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationByCertificateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetOrganizationByCertificateId (@certificateId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_Certificate AS ec ON o.Id = ec.OrganizationId AND ec.IsDeleted = 0
                   WHERE ec.Id = @certificateId  AND o.IsDeleted = 0 
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
