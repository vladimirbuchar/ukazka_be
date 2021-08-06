using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class AddCourseLessonItemDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Edu_CourseLessonItem");
            migrationBuilder.CreateDeleteProcedure("Edu_CourseLessonItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
