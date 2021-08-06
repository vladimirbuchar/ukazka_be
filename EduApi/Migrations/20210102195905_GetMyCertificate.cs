using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMyCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetMyCertificate(@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sbi.Name,uc.ActiveFrom,uc.FileName FROM Edu_UserCertificate AS uc
JOIN Shared_BasicInformation AS sbi ON uc.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE uc.UserId =@userId AND uc.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
