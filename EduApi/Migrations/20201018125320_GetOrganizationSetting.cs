using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create  FUNCTION GetOrganizationSetting(@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT OrganizationId,UserDefaultPassword  from Edu_OrganizationSetting WHERE IsDeleted= 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
