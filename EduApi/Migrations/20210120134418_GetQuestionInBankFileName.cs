using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetQuestionInBankFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetQuestionInBank](@BankOfQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, cam.Value AS AnswerMode, sbi.Name AS BankOfQuestionName, boq.IsDefault,tq.Position, boq.Position AS BankOfQuestionPosition, 
boq.Id AS BankOfQuestionId,tq.QuestionModeId, cqm.Value AS QuestionMode, fr.FileName
FROM Edu_TestQuestion AS tq
JOIN Cb_AnswerMode AS cam ON tq.AnswerModeId = cam.Id
JOIN Cb_QuestionMode AS cqm ON tq.QuestionModeId = cqm.Id
JOIN Edu_BankOfQuestion AS boq ON tq.BankOfQuestionId = boq.Id AND boq.IsDeleted = 0
JOIN Shared_BasicInformation AS sbi ON boq.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
JOIN Edu_FileRepository AS fr ON fr.ObjectOwner = tq.Id
WHERE boq.Id= @BankOfQuestionId and tq.IsDeleted= 0 AND tq.Question !=''
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
