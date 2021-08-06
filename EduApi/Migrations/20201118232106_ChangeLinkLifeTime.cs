using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ChangeLinkLifeTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_User_Edu_LinkLifeTime_LinkLifeTimeId",
                table: "Edu_User");

            migrationBuilder.DropIndex(
                name: "IX_Edu_User_LinkLifeTimeId",
                table: "Edu_User");

            migrationBuilder.DropColumn(
                name: "LinkLifeTimeId",
                table: "Edu_User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Edu_LinkLifeTime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_LinkLifeTime_UserId",
                table: "Edu_LinkLifeTime",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_LinkLifeTime_Edu_User_UserId",
                table: "Edu_LinkLifeTime",
                column: "UserId",
                principalTable: "Edu_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_LinkLifeTime_Edu_User_UserId",
                table: "Edu_LinkLifeTime");

            migrationBuilder.DropIndex(
                name: "IX_Edu_LinkLifeTime_UserId",
                table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Edu_LinkLifeTime");

            migrationBuilder.AddColumn<Guid>(
                name: "LinkLifeTimeId",
                table: "Edu_User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_User_LinkLifeTimeId",
                table: "Edu_User",
                column: "LinkLifeTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_User_Edu_LinkLifeTime_LinkLifeTimeId",
                table: "Edu_User",
                column: "LinkLifeTimeId",
                principalTable: "Edu_LinkLifeTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
