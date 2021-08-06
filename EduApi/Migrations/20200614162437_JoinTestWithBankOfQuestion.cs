using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class JoinTestWithBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("JoinTestWithBankOfQuestion", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Link_TestBankOfQuestion",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@BankOfQuestionId","uniqueidentifier" },
                    {"@CourseTestId","uniqueidentifier" }
                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
