using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddOrganizationInsertProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateInsertProcedure("CreateOrganization", new Core.DataTypes.InsertProcedureTableConfig()
            {
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>() { { "@CanSendCourseInquiry", "bit" }, { "@LicenseId", "uniqueidentifier" } },
                SaveBasicInformation = true,
                TableName = "Edu_Organization",
                SaveContactInformation = true
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
