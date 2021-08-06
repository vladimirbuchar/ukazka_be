using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateBankOfQuestionAddIsNullů : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateBankOfQuestion] 
@OrganizationId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@IsDefault bit

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_BankOfQuestion_id uniqueidentifier 
SET @Edu_BankOfQuestion_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_BankOfQuestion 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, OrganizationId, BasicInformationId,IsDefault,Position) VALUES 
(@Edu_BankOfQuestion_id, 0, 0, 1, null, @OrganizationId, @BasicInformationId,@IsDefault,ISNULL((SELECT MAX(Position) FROM Edu_BankOfQuestion WHERE OrganizationId = @OrganizationId),0)+1); 
SELECT @Edu_BankOfQuestion_id AS OutGuid

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
