using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class Cb_SendMessageTypeChangeDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_SendMessageType SET IsDefault = 0 WHERE Value = 'EMAIL' OR Value = 'SMS'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
