using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace EduApi.Migrations
{
    public partial class SetIsActiveTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<string> ignoredTable = migrationBuilder.IgnoreTable();
            ignoredTable.Add("Edu_LinkLifeTime");
            foreach (string item in migrationBuilder.GetAllTables())
            {
                if (ignoredTable.Contains(item))
                {
                    continue;
                }
                migrationBuilder.Sql($"UPDATE {item} SET IsActive =1 WHERE IsDeleted = 0");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
