using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangePriorityLicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 1 Where Value= 'FREE_LICENSE'");
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 2 Where Value= 'STANDARD_LICENSE'");
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 3 Where Value= 'PROFESIONAL_LICENSE'");
            migrationBuilder.Sql(@"UPDATE cb_license SET Priority = 4 Where Value= 'ENTERPRISE_LICENSE'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
