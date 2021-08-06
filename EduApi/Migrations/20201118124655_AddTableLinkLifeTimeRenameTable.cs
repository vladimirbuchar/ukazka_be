using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddTableLinkLifeTimeRenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkLifeTime");

            migrationBuilder.CreateTable(
                name: "Edu_LinkLifeTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    ObjectId = table.Column<Guid>(nullable: false),
                    ObjectName = table.Column<string>(nullable: true),
                    LifeTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_LinkLifeTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LinkLifeTime_SystemIdentificator",
                table: "Edu_LinkLifeTime",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_LinkLifeTime");

            migrationBuilder.CreateTable(
                name: "LinkLifeTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsChanged = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(type: "bit", nullable: false),
                    LifeTime = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemIdentificator = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkLifeTime", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkLifeTime_SystemIdentificator",
                table: "LinkLifeTime",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }
    }
}
