using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CbQuestionModeUpdateValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"  UPDATE Edu_TestQuestion  SET QuestionModeId = (SELECT  Id
  FROM Cb_QuestionMode
  WHERE SystemIdentificator = 'TEXT_QUESTION')
  UPDATE Cb_QuestionMode SET IsDefault = 1 WHERE SystemIdentificator = 'CODEBOOK_SELECT_VALUE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
