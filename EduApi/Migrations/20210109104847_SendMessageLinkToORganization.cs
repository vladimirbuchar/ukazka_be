using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class SendMessageLinkToORganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Edu_SendMessage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessage_OrganizationId",
                table: "Edu_SendMessage",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_SendMessage_Edu_Organization_OrganizationId",
                table: "Edu_SendMessage",
                column: "OrganizationId",
                principalTable: "Edu_Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_SendMessage_Edu_Organization_OrganizationId",
                table: "Edu_SendMessage");

            migrationBuilder.DropIndex(
                name: "IX_Edu_SendMessage_OrganizationId",
                table: "Edu_SendMessage");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Edu_SendMessage");
        }
    }
}
