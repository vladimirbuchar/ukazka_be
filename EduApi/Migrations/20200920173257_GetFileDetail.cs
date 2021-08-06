using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetFileDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetFileDetail(@fileId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id, FileName,OriginalFileName,ObjectOwner FROM Edu_FileRepository WHERE IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
