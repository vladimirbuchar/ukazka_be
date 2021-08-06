using Core.Extension;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class SendMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edu_SendMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: true, defaultValue: true),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    BasicInformationId = table.Column<Guid>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    SendMessageTypeId = table.Column<Guid>(nullable: true),
                    Reply = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edu_SendMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edu_SendMessage_Shared_BasicInformation_BasicInformationId",
                        column: x => x.BasicInformationId,
                        principalTable: "Shared_BasicInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edu_SendMessage_Cb_SendMessageType_SendMessageTypeId",
                        column: x => x.SendMessageTypeId,
                        principalTable: "Cb_SendMessageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessage_BasicInformationId",
                table: "Edu_SendMessage",
                column: "BasicInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessage_SendMessageTypeId",
                table: "Edu_SendMessage",
                column: "SendMessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edu_SendMessage_SystemIdentificator",
                table: "Edu_SendMessage",
                column: "SystemIdentificator",
                unique: true,
                filter: "[SystemIdentificator] IS NOT NULL");
            migrationBuilder.SetDefaultTable("Edu_SendMessage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edu_SendMessage");
        }
    }
}
