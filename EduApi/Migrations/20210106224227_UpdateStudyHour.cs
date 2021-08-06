using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateStudyHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  PROCEDURE [dbo].UpdateStudyHour 
@Id uniqueidentifier,
@ActiveFromId uniqueidentifier,
@ActiveToId uniqueidentifier,
@Position int


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

UPDATE Edu_OrganizationStudyHour SET ActiveFromId =@ActiveFromId, ActiveToId =@ActiveToId, Position =@Position WHERE Id =@Id



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
