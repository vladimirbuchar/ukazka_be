using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class AddIsDeletedToNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> tables = new List<string>()
            {
                "Edu_OrganizationSetting",
            "Edu_StudentTestSummaryAnswer","Edu_StudentTestSummaryQuestion",
            "Link_CourseBrowse","Link_CouseStudentMaterial"
            };
            foreach (string item in tables)
            {
                // migrationBuilder.DropTrigger(string.Format("SetIsDeleted_{0}", item));
                migrationBuilder.AddTriggerIsDeleted(item);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
