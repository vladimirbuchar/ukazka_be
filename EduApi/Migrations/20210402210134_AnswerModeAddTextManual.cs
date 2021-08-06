using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerModeAddTextManual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cb_AnswerMode ([Id]
      ,[IsDeleted]
      ,[IsSystemObject]
      ,[IsChanged]
      ,[SystemIdentificator]
      ,[Name]
      ,[Value]
      ,[IsDefault]
      ,[Priority]
      ,[IsActive])
	  VALUES(
	  NEWID(),0,1,1,'TEXT_MANUAL','TEXT_MANUAL','TEXT_MANUAL',0,13,1
	  )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
