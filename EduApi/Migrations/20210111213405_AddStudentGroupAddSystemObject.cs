using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudentGroupAddSystemObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddStudentGroup]
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

INSERT INTO Shared_BasicInformation(Id,IsDeleted,IsChanged,SystemIdentificator,Name,Description,IsActive,CultureId,IsSystemObject) VALUES
(@sbi_id,0,1,null,@Name,'',1,null,0)

INSERT INTO Edu_StudentGroup(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,BasicInformationId,OrganizationId)
VALUES                     (@id,0,0,1,null,1,@sbi_id,@OrganizationId);

SELECT @id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
