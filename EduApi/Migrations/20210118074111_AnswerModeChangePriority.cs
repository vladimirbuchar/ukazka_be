using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerModeChangePriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_AnswerMode SET Priority = 1 WHERE SystemIdentificator = 'TEXT'

UPDATE Cb_AnswerMode SET Priority = 2 WHERE SystemIdentificator = 'SELECT_ONE'
UPDATE Cb_AnswerMode SET Priority = 3 WHERE SystemIdentificator = 'SELECT_MANY'
UPDATE Cb_AnswerMode SET Priority = 4 WHERE SystemIdentificator = 'YES_NO_TRUE_YES'
UPDATE Cb_AnswerMode SET Priority = 5 WHERE SystemIdentificator = 'YES_NO_TRUE_NO'
UPDATE Cb_AnswerMode SET Priority = 6 WHERE SystemIdentificator = 'SELECT_ONE_IMAGE'
UPDATE Cb_AnswerMode SET Priority = 7 WHERE SystemIdentificator = 'SELECT_ONE_VIDEO'
UPDATE Cb_AnswerMode SET Priority = 8 WHERE SystemIdentificator = 'SELECT_ONE_AUDIO'
UPDATE Cb_AnswerMode SET Priority = 9 WHERE SystemIdentificator = 'SELECT_MANY_IMAGE'
UPDATE Cb_AnswerMode SET Priority = 10 WHERE SystemIdentificator = 'SELECT_MANY_VIDEO'
UPDATE Cb_AnswerMode SET Priority = 11 WHERE SystemIdentificator = 'SELECT_MANY_AUDIO'
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
