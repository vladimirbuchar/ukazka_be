using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class NoteTypeAdd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFile",
                table: "Edu_Note");

            migrationBuilder.AddColumn<Guid>(
                name: "NoteTypeId",
                table: "Edu_Note",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cb_NoteType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cb_NoteType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Note_NoteTypeId",
                table: "Edu_Note",
                column: "NoteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cb_NoteType_SystemIdentificator",
                table: "Cb_NoteType",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Note_Cb_NoteType_NoteTypeId",
                table: "Edu_Note",
                column: "NoteTypeId",
                principalTable: "Cb_NoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Note_Cb_NoteType_NoteTypeId",
                table: "Edu_Note");

            migrationBuilder.DropTable(
                name: "Cb_NoteType");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Note_NoteTypeId",
                table: "Edu_Note");

            migrationBuilder.DropColumn(
                name: "NoteTypeId",
                table: "Edu_Note");

            migrationBuilder.AddColumn<bool>(
                name: "IsFile",
                table: "Edu_Note",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
