using Microsoft.EntityFrameworkCore.Migrations;
using Core.Extension;
namespace EduApi.Migrations
{
    public partial class NoteTypeAddvaluesDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCodeBookDefaultValue("Cb_NoteType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
