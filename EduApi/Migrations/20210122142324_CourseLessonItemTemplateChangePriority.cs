using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CourseLessonItemTemplateChangePriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
UPDATE Cb_CourseLessonItemTemplate SET Priority = 1 WHERE SystemIdentificator = 'BASIC_TEMPLATE'
  UPDATE Cb_CourseLessonItemTemplate SET Priority = 2 WHERE SystemIdentificator = 'BASIC_TEMPLATE_IMAGE'
  UPDATE Cb_CourseLessonItemTemplate SET Priority = 3 WHERE SystemIdentificator = 'VIDEO'
  UPDATE Cb_CourseLessonItemTemplate SET Priority = 4 WHERE SystemIdentificator = 'AUDIO'
  UPDATE Cb_CourseLessonItemTemplate SET Priority = 5 WHERE SystemIdentificator = 'YOUTUBE'
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
