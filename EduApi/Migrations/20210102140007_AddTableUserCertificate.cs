using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace EduApi.Migrations
{
    public partial class AddTableUserCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_UserCertificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    UserId = table.Column<Guid>(nullable: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    FileRepositoryId = table.Column<Guid>(nullable: true),
                    ActiveFrom = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_UserCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_UserCertificate_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_UserCertificate_Edu_FileRepository_FileRepositoryId",
                        column: x => x.FileRepositoryId,
                        principalTable: "Edu_FileRepository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_UserCertificate_Edu_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Edu_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_BasicInformationId",
                table: "Edu_UserCertificate",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_FileRepositoryId",
                table: "Edu_UserCertificate",
                column: "FileRepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_SystemIdentificator",
                table: "Edu_UserCertificate",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_UserCertificate_UserId",
                table: "Edu_UserCertificate",
                column: "UserId");
            migrationBuilder.SetDefaultTable("Edu_UserCertificate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_UserCertificate");
        }
    }
}
