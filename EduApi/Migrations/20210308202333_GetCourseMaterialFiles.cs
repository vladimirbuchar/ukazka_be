using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCourseMaterialFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetCourseMaterialFiles(@courseMaterialId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT Id,ObjectOwner,FileName,OriginalFileName FROM Edu_FileRepository WHERE ObjectOwner = @courseMaterialId AND IsDeleted  = 0
                             
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
