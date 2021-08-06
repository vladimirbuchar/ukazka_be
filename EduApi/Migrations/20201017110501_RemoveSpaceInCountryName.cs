using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class RemoveSpaceInCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Update Cb_Country SET Name= LTRIM(RTRIM(Name))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
