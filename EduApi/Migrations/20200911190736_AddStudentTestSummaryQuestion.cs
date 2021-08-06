using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddStudentTestSummaryQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "@StudentTestSummaryId", "uniqueidentifier" },
                { "@TestQuestionId", "uniqueidentifier" },
                { "@Score", "int" },
                { "@IsAutomaticEvaluate", "bit" },
                { "@IsTrue", "bit" }
            };
            migrationBuilder.CreateInsertProcedure("AddStudentTestSummaryQuestion", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_StudentTestSummaryQuestion",
                InsertColumns = param
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
