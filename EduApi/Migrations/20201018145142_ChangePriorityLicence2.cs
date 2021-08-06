using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangePriorityLicence2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 4 Where Value= 'ENTERPRISE_LICENSE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
