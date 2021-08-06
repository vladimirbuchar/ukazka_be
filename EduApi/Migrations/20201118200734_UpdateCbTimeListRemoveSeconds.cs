using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCbTimeListRemoveSeconds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_TimeTable SET Name = substring(Name, 0, len(Name)-2 )");
            migrationBuilder.Sql(@"UPDATE Cb_TimeTable SET Value = substring(Name, 0, len(Value)-2 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
