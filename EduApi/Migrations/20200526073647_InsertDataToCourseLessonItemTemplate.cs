using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class InsertDataToCourseLessonItemTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] columns = new string[]
            {
                "Id","IsDeleted","IsSystemObject","IsChanged","SystemIdentificator","Name","Value","IsDefault","Priority"
            };
            object[] values = new object[]
            {
                Guid.NewGuid(),false,true,true,"BASIC_TEMPLATE","BASIC_TEMPLATE","BASIC_TEMPLATE",false,0
            };
            migrationBuilder.InsertData("Cb_CourseLessonItemTemplate", columns, values);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
