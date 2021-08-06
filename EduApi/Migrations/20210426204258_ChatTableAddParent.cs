using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChatTableAddParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Edu_Chat",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Chat_ParentId",
                table: "Edu_Chat",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Chat_Edu_Chat_ParentId",
                table: "Edu_Chat",
                column: "ParentId",
                principalTable: "Edu_Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Chat_Edu_Chat_ParentId",
                table: "Edu_Chat");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Chat_ParentId",
                table: "Edu_Chat");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Edu_Chat");
        }
    }
}
