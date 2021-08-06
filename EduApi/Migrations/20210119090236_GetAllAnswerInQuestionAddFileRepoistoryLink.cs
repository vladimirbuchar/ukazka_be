using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllAnswerInQuestionAddFileRepoistoryLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllAnswerInQuestion](@TestQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tqa.Id, tqa.Answer, tqa.IsTrueAnswer,tqa.Position, fr.Id AS FileId, fr.FileName FROM Edu_TestQuestionAnswer AS tqa
LEFT JOIN Edu_FileRepository AS fr ON tqa.Id = fr.ObjectOwner AND fr.IsDeleted = 0
                WHERE tqa.TestQuestionId = @TestQuestionId AND tqa.IsDeleted = 0
)
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAnswerDetail](@answerId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT tqa.Id, tqa.Answer, tqa.IsTrueAnswer, fr.Id AS FileId, fr.FileName  FROM Edu_TestQuestionAnswer AS tqa
LEFT JOIN Edu_FileRepository AS fr ON tqa.Id = fr.ObjectOwner AND fr.IsDeleted = 0
                WHERE tqa.Id = @answerId AND tqa.IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
