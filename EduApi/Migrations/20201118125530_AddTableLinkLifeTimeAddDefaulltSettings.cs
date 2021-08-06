using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddTableLinkLifeTimeAddDefaulltSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SetDefaultTable("Edu_LinkLifeTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
