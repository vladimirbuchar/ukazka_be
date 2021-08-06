using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddSendMessageAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddSendMessage]
@OrganizationId uniqueidentifier,
@Html nvarchar(max), 

@Name nvarchar(max),
@Reply nvarchar(max),
@SendMessageType uniqueidentifier


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @id uniqueidentifier 
DECLARE @sbi_id uniqueidentifier 
SET @id  = NEWID() 
SET @sbi_id  = NEWID() 

INSERT INTO Shared_BasicInformation(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Description,IsActive,CultureId) VALUES
(@sbi_id,0,0,1,null,@Name,'',1,null)

INSERT INTO Edu_SendMessage(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,BasicInformationId,Html,SendMessageTypeId,Reply,OrganizationId)
VALUES                     (@id,0,0,1,null,1,@sbi_id,@Html,@SendMessageType,@Reply,@OrganizationId);




SELECT @id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
