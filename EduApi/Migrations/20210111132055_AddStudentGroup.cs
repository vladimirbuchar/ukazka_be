using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudentGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE AddStudentGroup
@OrganizationId uniqueidentifier,
@Name nvarchar(max)

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @id uniqueidentifier 
DECLARE @sbi_id uniqueidentifier 
SET @id  = NEWID() 
SET @sbi_id  = NEWID() 

INSERT INTO Shared_BasicInformation(Id,IsDeleted,IsChanged,SystemIdentificator,Name,Description,IsActive,CultureId) VALUES
(@sbi_id,0,1,null,@Name,'',1,null)

INSERT INTO Edu_StudentGroup(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,BasicInformationId,OrganizationId)
VALUES                     (@id,0,0,1,null,1,@sbi_id,@OrganizationId);

SELECT @id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 

");
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].UpdateStudentGroup
@Id uniqueidentifier,
@Name nvarchar(max)



AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @sbi_id uniqueidentifier 

SET @sbi_id  = (SELECT BasicInformationId FROM Edu_SendMessage WHERE Id =@Id )
UPDATE Shared_BasicInformation SET Name= @Name WHERE Id =@sbi_id


COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetStudentGroupInOrganization (@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sm.Id, sbi.Name FROM Edu_StudentGroup AS sm
JOIN Shared_BasicInformation AS sbi ON sbi.Id = sm.BasicInformationId AND sbi.IsDeleted = 0
WHERE sm.OrganizationId =@organizationId AND sm.IsDeleted = 0

)");
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetStudentGroupDetail (@studentGroupId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sm.Id, sbi.Name FROM Edu_StudentGroup AS sm
JOIN Shared_BasicInformation AS sbi ON sbi.Id = sm.BasicInformationId AND sbi.IsDeleted = 0
WHERE sm.Id =@studentGroupId AND sm.IsDeleted = 0

)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
