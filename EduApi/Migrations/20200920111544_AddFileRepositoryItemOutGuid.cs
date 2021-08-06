using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddFileRepositoryItemOutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE AddFileRepositoryItem
@ObjectOwner uniqueidentifier 
,@FileName nvarchar(max) 
,@OriginalFileName nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_FileRepository_id uniqueidentifier 
SET @Edu_FileRepository_id  = NEWID() 
INSERT INTO Edu_FileRepository 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, ObjectOwner, FileName, OriginalFileName) VALUES 
(@Edu_FileRepository_id, 0, 0, 1, null, @ObjectOwner, @FileName, @OriginalFileName); 
SELECT @Edu_FileRepository_id AS OutGuid
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
