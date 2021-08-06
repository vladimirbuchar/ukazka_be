using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddLinkCourseToCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shared_Gallery_Edu_Course_CourseId",
                table: "Shared_Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Shared_Gallery_CourseId",
                table: "Shared_Gallery");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Shared_Gallery");

            migrationBuilder.AddColumn<Guid>(
                name: "CertificateId",
                table: "Edu_Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edu_Course_CertificateId",
                table: "Edu_Course",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_Course_Edu_Certificate_CertificateId",
                table: "Edu_Course",
                column: "CertificateId",
                principalTable: "Edu_Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_Course_Edu_Certificate_CertificateId",
                table: "Edu_Course");

            migrationBuilder.DropIndex(
                name: "IX_Edu_Course_CertificateId",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Edu_Course");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Shared_Gallery",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Gallery_CourseId",
                table: "Shared_Gallery",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_Gallery_Edu_Course_CourseId",
                table: "Shared_Gallery",
                column: "CourseId",
                principalTable: "Edu_Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
