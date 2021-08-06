using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class DeleteFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_AnswerMode SET IsDeleted = 1 WHERE SystemIdentificator = 'FILE_UPLOAD'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
