using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddPositionToResauultQuestionAnswere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetQuestionInOrganization](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, cam.Value AS AnswerMode, sbi.Name AS BankOfQuestionName, boq.IsDefault,tq.Position FROM Edu_TestQuestion AS tq
JOIN Cb_AnswerMode AS cam ON tq.AnswerModeId = cam.Id
JOIN Edu_BankOfQuestion AS boq ON tq.BankOfQuestionId = boq.Id AND boq.IsDeleted = 0
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE boq.OrganizationId= @OrganizationId and tq.IsDeleted= 0 
)");

            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllAnswerInQuestion](@TestQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tqa.Id, tqa.Answer, tqa.IsTrueAnswer,tqa.Position FROM Edu_TestQuestionAnswer AS tqa
                WHERE tqa.TestQuestionId = @TestQuestionId AND tqa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
