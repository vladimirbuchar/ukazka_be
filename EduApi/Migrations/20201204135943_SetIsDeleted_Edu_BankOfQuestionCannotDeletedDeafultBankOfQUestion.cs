using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetIsDeleted_Edu_BankOfQuestionCannotDeletedDeafultBankOfQUestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_BankOfQuestion] 
ON [dbo].[Edu_BankOfQuestion] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0  AND u.IsDefault = 0
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_BankOfQuestion', 'DELETE', SYSDATETIME(), null); 

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
