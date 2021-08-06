using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetIdentificatorInAnswerMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Cb_AnswerMode SET SystemIdentificator = Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
