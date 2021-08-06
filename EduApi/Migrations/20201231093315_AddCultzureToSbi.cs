using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddCultzureToSbi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CultureId",
                table: "Shared_BasicInformation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shared_BasicInformation_CultureId",
                table: "Shared_BasicInformation",
                column: "CultureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shared_BasicInformation_Cb_Culture_CultureId",
                table: "Shared_BasicInformation",
                column: "CultureId",
                principalTable: "Cb_Culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shared_BasicInformation_Cb_Culture_CultureId",
                table: "Shared_BasicInformation");

            migrationBuilder.DropIndex(
                name: "IX_Shared_BasicInformation_CultureId",
                table: "Shared_BasicInformation");

            migrationBuilder.DropColumn(
                name: "CultureId",
                table: "Shared_BasicInformation");
        }
    }
}
