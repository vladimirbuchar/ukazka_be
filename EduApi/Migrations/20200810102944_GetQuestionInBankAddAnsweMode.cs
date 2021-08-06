using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetQuestionInBankAddAnsweMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION GetQuestionInBank(@BankOfQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, cam.Value AS AnswerMode FROM Edu_TestQuestion AS tq
JOIN Cb_AnswerMode AS cam ON tq.AnswerModeId = cam.Id
WHERE tq.BankOfQuestionId = @BankOfQuestionId and tq.IsDeleted= 0 
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
