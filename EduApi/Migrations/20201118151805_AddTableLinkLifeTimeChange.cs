using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddTableLinkLifeTimeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LifeTime",
                table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(
                name: "ObjectId",
                table: "Edu_LinkLifeTime");

            migrationBuilder.DropColumn(
                name: "ObjectName",
                table: "Edu_LinkLifeTime");

            migrationBuilder.AddColumn<Guid>(
                name: "LinkLifeTimeId",
                table: "Edu_User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Edu_LinkLifeTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Edu_LinkLifeTime");

            migrationBuilder.AddColumn<int>(
                name: "LifeTime",
                table: "Edu_LinkLifeTime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ObjectId",
                table: "Edu_LinkLifeTime",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ObjectName",
                table: "Edu_LinkLifeTime",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
