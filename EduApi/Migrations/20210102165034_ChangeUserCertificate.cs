using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class ChangeUserCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_UserCertificate_Edu_FileRepository_FileRepositoryId",
                table: "Edu_UserCertificate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_UserCertificate_FileRepositoryId",
                table: "Edu_UserCertificate");

            migrationBuilder.DropColumn(
                name: "FileRepositoryId",
                table: "Edu_UserCertificate");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Edu_UserCertificate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Edu_UserCertificate");

            migrationBuilder.AddColumn<Guid>(
                name: "FileRepositoryId",
                table: "Edu_UserCertificate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_FileRepositoryId",
                table: "Edu_UserCertificate",
                column: "FileRepositoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_UserCertificate_Edu_FileRepository_FileRepositoryId",
                table: "Edu_UserCertificate",
                column: "FileRepositoryId",
                principalTable: "Edu_FileRepository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
