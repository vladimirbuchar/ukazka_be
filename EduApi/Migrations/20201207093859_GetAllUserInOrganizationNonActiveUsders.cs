using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllUserInOrganizationNonActiveUsders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddUserToOrganization] 
@OrganizationId uniqueidentifier 
,@OrganizationRoleId uniqueidentifier 
,@UserId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Link_UserInOrganization_id uniqueidentifier 
SET @Link_UserInOrganization_id  = NEWID() 
INSERT INTO Link_UserInOrganization 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, OrganizationId, OrganizationRoleId, UserId) VALUES 
(@Link_UserInOrganization_id, 0, 0, 1, null, @OrganizationId, @OrganizationRoleId, @UserId); 
SELECT @Link_UserInOrganization_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 

");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllUserInOrganization](@organizationOid uniqueidentifier)
RETURNS TABLE  AS
RETURN
(
SELECT uio.Id, p.FirstName, p.SecondName, p.LastName, u.UserEmail, orl.SystemIdentificator AS UserRole, uio.UserId, u.IsActive
                             FROM Edu_User AS u
                             JOIN Edu_Person as p ON u.PersonId = p.Id AND p.IsDeleted = 0
                             JOIN Link_UserInOrganization AS uio ON uio.UserId = u.Id AND uio.IsDeleted = 0
                             JOIN Edu_OrganizationRole AS orl ON orl.Id = uio.OrganizationRoleId AND orl.IsDeleted =0
                             WHERE uio.OrganizationId = @organizationOid
                                     AND  u.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
