using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateSendMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateSendMessage
@Id uniqueidentifier,
@Html nvarchar(max), 
@Name nvarchar(max),
@Reply nvarchar(max),
@SendMessageType uniqueidentifier


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @sbi_id uniqueidentifier 

SET @sbi_id  = (SELECT BasicInformationId FROM Edu_SendMessage WHERE Id =@Id )

UPDATE Shared_BasicInformation SET Name= @Name WHERE Id =@sbi_id
UPDATE Edu_SendMessage SET 
Html =@Html,
Reply =@Reply,
SendMessageTypeId  =@SendMessageType
WHERE Id=@Id


COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END 
");
            migrationBuilder.Sql(@"CREATE FUNCTION GetSendMessageInOrganization (@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sm.Id, sbi.Name FROM Edu_SendMessage AS sm
JOIN Shared_BasicInformation AS sbi ON sbi.Id = sm.BasicInformationId AND sbi.IsDeleted = 0
WHERE sm.OrganizationId =@organizationId AND sm.IsDeleted = 0

)");
            migrationBuilder.Sql(@"CREATE FUNCTION GetSendMessageDetail (@sendMessageId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sm.Id, sbi.Name,Html,SendMessageTypeId,Reply FROM Edu_SendMessage AS sm
JOIN Shared_BasicInformation AS sbi ON sbi.Id = sm.BasicInformationId AND sbi.IsDeleted = 0
WHERE sm.Id =@sendMessageId AND sm.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
