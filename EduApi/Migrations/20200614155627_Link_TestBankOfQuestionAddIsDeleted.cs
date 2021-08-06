using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class Link_TestBankOfQuestionAddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddTriggerIsDeleted("Link_TestBankOfQuestion");
            migrationBuilder.CreateDeleteProcedure("Link_TestBankOfQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
