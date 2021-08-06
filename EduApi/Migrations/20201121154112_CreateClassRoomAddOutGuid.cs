using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateClassRoomAddOutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateClassRoom] 
@Floor int 
,@BranchId uniqueidentifier 
,@MaxCapacity int 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_ClassRoom_id uniqueidentifier 
SET @Edu_ClassRoom_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_ClassRoom 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Floor, BranchId, MaxCapacity, BasicInformationId) VALUES 
(@Edu_ClassRoom_id, 0, 0, 1, null, @Floor, @BranchId, @MaxCapacity, @BasicInformationId); 
SELECT @Edu_ClassRoom_id AS OutGuid
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
