using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateSetIsActiveProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (string item in migrationBuilder.GetAllTables())
            {
                migrationBuilder.CreateSetIsActiveProcedure(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
