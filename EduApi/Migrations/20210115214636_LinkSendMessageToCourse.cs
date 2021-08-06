using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class LinkSendMessageToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendEmail",
                table: "Edu_Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SendMessageId",
                table: "Edu_Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_SendMessageId",
                table: "Edu_Course",
                column: "SendMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_SendMessage_SendMessageId",
                table: "Edu_Course",
                column: "SendMessageId",
                principalTable: "Edu_SendMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Course_Edu_SendMessage_SendMessageId",
                table: "Edu_Course");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Course_SendMessageId",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "SendEmail",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "SendMessageId",
                table: "Edu_Course");
        }
    }
}
