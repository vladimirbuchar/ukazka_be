using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class CertificateTableChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Edu_Certificate");

            migrationBuilder.AddColumn<Guid>(
                name: "BasicInformationId",
                table: "Edu_Certificate",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Certificate_BasicInformationId",
                table: "Edu_Certificate",
                column: "BasicInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Certificate_Shared_BasicInformation_BasicInformationId",
                table: "Edu_Certificate",
                column: "BasicInformationId",
                principalTable: "Shared_BasicInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Certificate_Shared_BasicInformation_BasicInformationId",
                table: "Edu_Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Certificate_BasicInformationId",
                table: "Edu_Certificate");

            migrationBuilder.DropColumn(
                name: "BasicInformationId",
                table: "Edu_Certificate");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Edu_Certificate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
