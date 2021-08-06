using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class Cb_CourseLessonItemTemplateIsDeletedTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Cb_CourseLessonItemTemplate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
