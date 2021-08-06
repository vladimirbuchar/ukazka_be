using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddOrganizationCulture2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_OrganizationCulture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    CultureId = table.Column<Guid>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_OrganizationCulture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_OrganizationCulture_Cb_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cb_Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_OrganizationCulture_Edu_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Edu_Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrganizationCulture_CultureId",
                table: "Link_OrganizationCulture",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrganizationCulture_OrganizationId",
                table: "Link_OrganizationCulture",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrganizationCulture_SystemIdentificator",
                table: "Link_OrganizationCulture",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Link_OrganizationCulture");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_OrganizationCulture");
        }
    }
}
