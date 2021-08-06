using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddStudentGroupToTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE AddStudentGroupToTerm
@courseTermId uniqueidentifier,
@studentGroupId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @id uniqueidentifier 
SET @id  = NEWID() 


INSERT INTO Link_StudentInGroupCourseTerm(Id,IsDeleted,IsChanged,SystemIdentificator,IsActive,IsSystemObject,CourseTermId,StudentGroupId) VALUES
(@id,0,1,null,1,0,@courseTermId,@studentGroupId)



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
