using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetEnvCultures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE [Cb_Culture] SET Priority = 1, IsEnvironmentCulture = 1 WHERE SystemIdentificator = 'en'
  UPDATE [Cb_Culture] SET Priority = 2, IsEnvironmentCulture = 1 WHERE SystemIdentificator = 'cs'
  UPDATE [Cb_Culture] SET Priority = 3, IsEnvironmentCulture = 1 WHERE SystemIdentificator = 'uk'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
