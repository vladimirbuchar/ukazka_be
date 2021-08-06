using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class Cb_AnswerModePriorityChnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 6 WHERE SystemIdentificator = 'SELECT_ONE_IMAGE'");
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 7 WHERE SystemIdentificator = 'SELECT_MANY_IMAGE'");
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 8 WHERE SystemIdentificator = 'SELECT_ONE_VIDEO'");
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 9 WHERE SystemIdentificator = 'SELECT_MANY_VIDEO'");
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 10 WHERE SystemIdentificator = 'SELECT_ONE_AUDIO'");
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET Priority = 11 WHERE SystemIdentificator = 'SELECT_MANY_AUDIO'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
