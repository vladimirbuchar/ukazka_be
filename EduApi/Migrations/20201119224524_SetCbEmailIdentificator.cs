using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetCbEmailIdentificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_Email SET SystemIdentificator = 'PASSWORD_RESET_cs-CZ' WHERE SystemIdentificator = 'PASSWORD_RESET_cs'");
            migrationBuilder.Sql(@"UPDATE Cb_Email SET SystemIdentificator = 'REGISTRATION_USER_cs-CZ' WHERE SystemIdentificator = 'REGISTRATION_USER_cs'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
