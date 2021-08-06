using Microsoft.EntityFrameworkCore.Migrations;
using Core.Extension;
namespace EduApi.Migrations
{
    public partial class StudentEvaluation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                table: "StudentEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEvaluation_Link_UserInOrganization_UserInOrganizationId",
                table: "StudentEvaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEvaluation",
                table: "StudentEvaluation");

            migrationBuilder.RenameTable(
                name: "StudentEvaluation",
                newName: "Edu_StudentEvaluation");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEvaluation_UserInOrganizationId",
                table: "Edu_StudentEvaluation",
                newName: "IX_Edu_StudentEvaluation_UserInOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEvaluation_SystemIdentificator",
                table: "Edu_StudentEvaluation",
                newName: "IX_Edu_StudentEvaluation_SystemIdentificator");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEvaluation_CourseTermId",
                table: "Edu_StudentEvaluation",
                newName: "IX_Edu_StudentEvaluation_CourseTermId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Edu_StudentEvaluation",
                table: "Edu_StudentEvaluation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                table: "Edu_StudentEvaluation",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Edu_StudentEvaluation_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_StudentEvaluation",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.SetDefaultTable("Edu_StudentEvaluation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                table: "Edu_StudentEvaluation");

            migrationBuilder.DropForeignKey(
                name: "FK_Edu_StudentEvaluation_Link_UserInOrganization_UserInOrganizationId",
                table: "Edu_StudentEvaluation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Edu_StudentEvaluation",
                table: "Edu_StudentEvaluation");

            migrationBuilder.RenameTable(
                name: "Edu_StudentEvaluation",
                newName: "StudentEvaluation");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_StudentEvaluation_UserInOrganizationId",
                table: "StudentEvaluation",
                newName: "IX_StudentEvaluation_UserInOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_StudentEvaluation_SystemIdentificator",
                table: "StudentEvaluation",
                newName: "IX_StudentEvaluation_SystemIdentificator");

            migrationBuilder.RenameIndex(
                name: "IX_Edu_StudentEvaluation_CourseTermId",
                table: "StudentEvaluation",
                newName: "IX_StudentEvaluation_CourseTermId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEvaluation",
                table: "StudentEvaluation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEvaluation_Edu_CourseTerm_CourseTermId",
                table: "StudentEvaluation",
                column: "CourseTermId",
                principalTable: "Edu_CourseTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEvaluation_Link_UserInOrganization_UserInOrganizationId",
                table: "StudentEvaluation",
                column: "UserInOrganizationId",
                principalTable: "Link_UserInOrganization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
