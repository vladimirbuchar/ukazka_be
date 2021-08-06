using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllClassRoomInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetAllClassRoomInOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description, c.IsOnline
                               FROM Edu_ClassRoom as c
							   JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
							   JOIN Edu_Branch AS b ON c.BranchId = b.Id AND b.IsDeleted = 0
							   JOIN Edu_Organization AS o ON b.OrganizationId = o.Id AND o.IsDeleted = 0
                               WHERE o.Id = @organizationId AND c.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
