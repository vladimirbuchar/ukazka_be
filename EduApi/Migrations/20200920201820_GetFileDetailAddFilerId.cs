using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetFileDetailAddFilerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetFileDetail](@fileId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id, FileName,OriginalFileName,ObjectOwner FROM Edu_FileRepository WHERE IsDeleted = 0 AND Id=@fileId
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
