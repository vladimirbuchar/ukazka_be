using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetQuestionDetailFileLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetQuestionDetail](@questionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tq.Id, tq.Question, tq.AnswerModeId, tq.BankOfQuestionId, am.SystemIdentificator AS AmIdentificator, tq.QuestionModeId, fr.Id AS FileId, fr.OriginalFileName
FROM Edu_TestQuestion as tq
JOIN Cb_AnswerMode AS am ON tq.AnswerModeId = am.Id AND am.IsDeleted = 0
LEFT JOIN Edu_FileRepository AS fr ON fr.ObjectOwner = tq.Id AND fr.IsDeleted = 0
WHERE  tq.Id =@questionId AND tq.IsDeleted = 0

)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
