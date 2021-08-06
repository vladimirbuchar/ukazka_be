using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
namespace EduApi.Migrations
{
    public partial class GetBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            System.Collections.Generic.Dictionary<string, string> pairs = new System.Collections.Generic.Dictionary<string, string>
            {
                { "@CourseTestId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetBankOfQuestion", "SELECT  BankOfQuestionId FROM Link_TestBankOfQuestion WHERE CourseTestId=@CourseTestId", pairs);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
