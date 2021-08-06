using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllBranchInOrganizationIsOnline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllBranchInOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT b.Id, b.IsMainBranch, a.CountryId, Region, City, Street, HouseNumber, ZipCode, bi.Name,cbc.Name AS CountryName,
                            bi.Description, Email, PhoneNumber, WWW,b.IsOnline    
                           FROM Edu_Branch as b
                           JOIN Shared_Address AS a on a.Id = b.AddressId AND a.IsDeleted = 0 
                           JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId AND b.IsDeleted = 0 
                           JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId AND bi.IsDeleted = 0 
						   JOIN Cb_Country as cbc ON a.CountryId = cbc.Id AND cbc.IsDeleted = 0
                            WHERE b.OrganizationId =@organizationId  
                            AND c.IsDeleted = 0
)
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllClassRoomInBranch](@branchId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description, c.IsOnline
                               FROM Edu_ClassRoom as c
                               JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                               WHERE c.BranchId = @branchId AND c.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetBranchDetail](@branchId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT b.Id,b.IsMainBranch, a.CountryId,Region,City,Street,HouseNumber,ZipCode,Name,
                                Description,Email,PhoneNumber,WWW 
                            FROM Edu_Branch as b
                            JOIN Shared_Address AS a on a.Id = b.AddressId AND b.IsDeleted = 0
                            JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId AND bi.IsDeleted = 0
                            JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId AND c.IsDeleted =0
                            WHERE b.Id = @branchId AND b.IsDeleted = 0 AND b.IsOnline = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetClassRoomDetail](@classRoomId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description
                                FROM Edu_ClassRoom as c
                                JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted =0
                                WHERE c.Id = @classRoomId AND c.IsDeleted = 0 AND c.IsOnline = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
