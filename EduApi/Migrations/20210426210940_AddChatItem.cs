using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddChatItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE AddChatItem

@UserId uniqueidentifier,
@Text nvarchar(max),
@ParentId uniqueidentifier,
@CourseTermId uniqueidentifier


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_TestQuestionAnswer_id uniqueidentifier 
SET @Edu_TestQuestionAnswer_id  = NEWID() 



INSERT INTO Edu_Chat 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, UserId,Text,ParentId,CourseTermId,Date) VALUES 
(@Edu_TestQuestionAnswer_id, 0, 0, 1, null, @UserId, @Text,@ParentId,@CourseTermId,SYSDATETIME()); 
SELECT @Edu_TestQuestionAnswer_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END;

");
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateChatItem

@Id uniqueidentifier,
@Text nvarchar(max)


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
Update Edu_Chat SET Text =@Text WHERE Id =@Id



COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END;");
            migrationBuilder.Sql(@"CREATE FUNCTION GetAllChatItem (@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id,Text,ParentId,UserId FROM Edu_Chat WHERE  CourseTermId = @courseTermId AND IsDeleted =0
)
");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
