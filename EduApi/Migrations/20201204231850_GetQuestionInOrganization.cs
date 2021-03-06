using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetQuestionInOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION GetQuestionInBank");
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetQuestionInOrganization](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, cam.Value AS AnswerMode, sbi.Name AS BankOfQuestionName FROM Edu_TestQuestion AS tq
JOIN Cb_AnswerMode AS cam ON tq.AnswerModeId = cam.Id
JOIN Edu_BankOfQuestion AS boq ON tq.BankOfQuestionId = boq.Id
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id
WHERE boq.OrganizationId= @OrganizationId and tq.IsDeleted= 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
