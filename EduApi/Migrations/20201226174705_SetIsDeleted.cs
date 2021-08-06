using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Edu_Certificate");
            migrationBuilder.CreateDeleteProcedure("Edu_Certificate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
