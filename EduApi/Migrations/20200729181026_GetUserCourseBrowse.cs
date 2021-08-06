using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class GetUserCourseBrowse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Dictionary<string, string> parametrs = new Dictionary<string, string>
            {
                { "@UserId", "uniqueidentifier" },
                { "@CouurseId", "uniqueidentifier" }
            };
            migrationBuilder.CreateSqlFunctionAsTable("GetUserCourseBrowse",
                @"SELECT CourseLessonItemId FROM Link_CourseBrowse WHERE IsDeleted = 0 AND UserId =@UserId AND CourseId = @CouurseId",
                parametrs
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
