using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class FileRepositoryAddDeleteTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Edu_FileRepository");
            migrationBuilder.CreateDeleteProcedure("Edu_FileRepository");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
