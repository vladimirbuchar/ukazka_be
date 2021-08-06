using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudentToGroupProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[AddStudentToGroup] 
@UserId uniqueidentifier 
,@StudentGroupId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Link_CourseStudent_id uniqueidentifier 
SET @Link_CourseStudent_id  = NEWID() 
INSERT INTO Link_StudentInGroup 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, UserId, StudentGroupId) VALUES 
(@Link_CourseStudent_id, 0, 0, 1, null, @UserId, @StudentGroupId); 
SELECT @Link_CourseStudent_id AS OutGuid
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
