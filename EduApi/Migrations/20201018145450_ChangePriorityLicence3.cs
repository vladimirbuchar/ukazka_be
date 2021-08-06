using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangePriorityLicence3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 4 Where Value= 'ENTERPRISEL_LICENSE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
