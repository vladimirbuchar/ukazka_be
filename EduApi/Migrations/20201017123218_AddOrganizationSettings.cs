using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddOrganizationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_OrganizationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_OrganizationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_OrganizationSetting_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationSetting_OrganizationId",
                table: "Edu_OrganizationSetting",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_OrganizationSetting_SystemIdentificator",
                table: "Edu_OrganizationSetting",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_OrganizationSetting");
        }
    }
}
