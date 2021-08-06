using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCodeBookSelectValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (string item in migrationBuilder.GetAllCodeBooks())
            {
                migrationBuilder.CreateCodeBookDefaultValue(item);
            }

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
