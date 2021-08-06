using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddImageQuestionToCb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cb_QuestionMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,Name,Value,IsDefault,Priority) VALUES
(NEWID(),0,1,1,'IMAGE_QUESTION',1,'IMAGE_QUESTION','IMAGE_QUESTION',0,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
