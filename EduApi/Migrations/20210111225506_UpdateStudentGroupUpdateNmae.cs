using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateStudentGroupUpdateNmae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[UpdateStudentGroup]
@Id uniqueidentifier,
@Name nvarchar(max)



AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @sbi_id uniqueidentifier 

SET @sbi_id  = (SELECT BasicInformationId FROM Edu_StudentGroup WHERE Id =@Id )
UPDATE Shared_BasicInformation SET Name= @Name WHERE Id =@sbi_id


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
