using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateLicencePOrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"UPDATE Cb_License SET MaximumCourse = 10 WHERE SystemIdentificator = 'FREE';
UPDATE Cb_License SET MounthPrice = 199 WHERE SystemIdentificator = 'ENTERPRISE';
UPDATE Cb_License SET MounthPrice = 59 WHERE SystemIdentificator = 'STANDARD';
UPDATE Cb_License SET MounthPrice = 129 WHERE SystemIdentificator = 'PROFESIONAL';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
