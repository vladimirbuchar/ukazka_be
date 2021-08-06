using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeCourseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_CourseStatus SET IsDeleted = 1 WHERE SystemIdentificator = 'NEW';
UPDATE Cb_CourseStatus SET IsDeleted = 1 WHERE SystemIdentificator = 'ONGOING';
UPDATE Cb_CourseStatus SET Priority = 2 WHERE SystemIdentificator = 'OPEN';
UPDATE Cb_CourseStatus SET Priority = 1 WHERE SystemIdentificator = 'IN_PREPARATION';
UPDATE Cb_CourseStatus SET Priority = 3 WHERE SystemIdentificator = 'CLOSED';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
