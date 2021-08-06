using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddStartTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@StartTime", "datetime" },
                { "@UserId", "uniqueidentifier" },
                { "@Finish", "datetime" },
                { "@TestCompleted", "bit" },
                { "@CourseTestId", "uniqueidentifier" }
            };
            migrationBuilder.CreateInsertProcedure("StartTest", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_StudentTestSummary",
                InsertColumns = param
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
