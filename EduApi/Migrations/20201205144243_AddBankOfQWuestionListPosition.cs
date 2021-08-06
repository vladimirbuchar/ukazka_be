using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddBankOfQWuestionListPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetBankOfQuestionInOrganization](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT boq.Id,sbi.Description,sbi.Name,boq.IsDefault,boq.Position   FROM Edu_BankOfQuestion AS boq
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE boq.OrganizationId = @OrganizationId AND boq.IsDeleted = 0
)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
