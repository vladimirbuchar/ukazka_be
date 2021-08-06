using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOnlineClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetOnlineClassRoom(@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description
                                FROM Edu_ClassRoom as c
                                JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted =0
								JOIN Edu_Branch AS b ON c.BranchId =  b.Id AND b.IsDeleted =0 AND b.IsOnline = 1
								JOIN Edu_Organization AS o ON b.OrganizationId = o.id AND o.IsDeleted =0 
                                WHERE o.Id = @organizationId AND c.IsDeleted = 0 AND c.IsOnline = 1

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
