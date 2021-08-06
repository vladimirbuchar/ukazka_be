using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveOrganizationSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateInsertProcedure("SaveOrganizationSetting", new Core.DataTypes.InsertProcedureTableConfig()
            {
                TableName = "Edu_OrganizationSetting",
                InsertColumns = new System.Collections.Generic.Dictionary<string, string>()
                {
                    {"@OrganizationId","uniqueidentifier" },{"@UserDefaultPassword","varchar(max)"}
                }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
