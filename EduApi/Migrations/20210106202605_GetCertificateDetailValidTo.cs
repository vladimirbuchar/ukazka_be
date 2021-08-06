using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetCertificateDetailValidTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCertificateDetail] (@certificateId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ec.Id,Html, sbi.Name, ec.CertificateValidTo FROM Edu_Certificate AS	ec
JOIN Shared_BasicInformation AS sbi ON ec.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE ec.Id = @certificateId AND ec.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
