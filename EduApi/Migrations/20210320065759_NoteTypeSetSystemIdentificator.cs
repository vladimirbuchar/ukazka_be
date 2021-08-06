using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class NoteTypeSetSystemIdentificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_NoteType SET SystemIdentificator = Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
