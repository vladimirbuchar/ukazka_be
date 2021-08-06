using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddStudentTestSummaryAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@TestQuestionAnswerId", "uniqueidentifier" },
                { "@StudentTestSummaryQuestionId", "uniqueidentifier" },
                { "@IsTrue", "bit" },
                { "@Text", "nvarchar(max)" }
            };
            migrationBuilder.CreateInsertProcedure("AddStudentTestSummaryAnswer", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_StudentTestSummaryAnswer",
                InsertColumns = param
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
