using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddNewCourseLessonItemTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'YOUTUBE','YOUTUBE','YOUTUBE',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'VIDEO','VIDEO','VIDEO',0,0,1);
INSERT INTO Cb_CourseLessonItemTemplate(Id,IsDeleted,IsSystemObject,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive)
VALUES (NEWID(),0,1,'AUDIO','AUDIO','AUDIO',0,0,1);
");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
