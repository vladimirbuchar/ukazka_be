using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCertificateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateCertificate] 
@Id uniqueidentifier, 
@Name nvarchar(max),
@Html nvarchar(max)


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Sbi uniqueidentifier;
SET @Sbi =(SELECT BasicInformationId FROM Edu_Certificate WHERE Id = @Id AND IsDeleted = 0)

UPDATE Shared_BasicInformation SET Name =@Name WHERE Id =@Sbi
UPDATE Edu_Certificate SET Html =@Html WHERE Id =@Id;

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
