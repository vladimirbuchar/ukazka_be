using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EduApi.Migrations
{
    public partial class AddLink_TestBankOfQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link_TestBankOfQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSystemObject = table.Column<bool>(nullable: false),
                    IsChanged = table.Column<bool>(nullable: false),
                    SystemIdentificator = table.Column<string>(nullable: true),
                    BankOfQuestionId = table.Column<Guid>(nullable: true),
                    CourseTestId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_TestBankOfQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_TestBankOfQuestion_Edu_BankOfQuestion_BankOfQuestionId",
                        column: x => x.BankOfQuestionId,
                        principalTable: "Edu_BankOfQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_TestBankOfQuestion_Edu_CourseTest_CourseTestId",
                        column: x => x.CourseTestId,
                        principalTable: "Edu_CourseTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_TestBankOfQuestion_BankOfQuestionId",
                table: "Link_TestBankOfQuestion",
                column: "BankOfQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_TestBankOfQuestion_CourseTestId",
                table: "Link_TestBankOfQuestion",
                column: "CourseTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_TestBankOfQuestion");
        }
    }
}
