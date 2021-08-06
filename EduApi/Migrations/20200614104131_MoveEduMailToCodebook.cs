using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class MoveEduMailToCodebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Cb_Email",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cb_Email",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Cb_Email",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Cb_Email",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Cb_Email");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cb_Email");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Cb_Email");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Cb_Email");
        }
    }
}
