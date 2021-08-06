using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetSendMessageInOrganizationAddType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetSendMessageInOrganization] (@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT sm.Id, sbi.Name,smt.SystemIdentificator  FROM Edu_SendMessage AS sm
JOIN Shared_BasicInformation AS sbi ON sbi.Id = sm.BasicInformationId AND sbi.IsDeleted = 0
JOIN Cb_SendMessageType AS smt ON smt.Id = sm.SendMessageTypeId AND smt.IsDeleted = 0
WHERE sm.OrganizationId =@organizationId AND sm.IsDeleted = 0

)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
