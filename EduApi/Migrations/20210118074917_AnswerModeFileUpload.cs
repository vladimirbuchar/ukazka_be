using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerModeFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'FILE_UPLOAD', 'FILE_UPLOAD', 'FILE_UPLOAD',0,12,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
