using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AlterSetActiveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (string item in migrationBuilder.GetAllTables())
            {
                migrationBuilder.Sql(@$"ALTER PROCEDURE SetIsActive_{item} 
@Id uniqueidentifier 

,@IsActive bit 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
UPDATE  {item} SET IsActive = @IsActive WHERE Id =@Id AND IsDeleted = 0
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
