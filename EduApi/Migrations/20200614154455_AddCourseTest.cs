using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddCourseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> columns = new Dictionary<string, string>
            {
                { "@IsRandomGenerateQuestion", "bit" },
                { "@QuestionCountInTest", "int" },
                { "@TimeLimit", "int" },
                { "@DesiredSuccess", "int" },
                { "@CourseLessonId", "uniqueidentifier" }
            };
            migrationBuilder.CreateInsertProcedure("AddCourseTest", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_CourseTest",
                InsertColumns = columns
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

