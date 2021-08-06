using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "System_ObjectHistory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "System_DataMigration",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_StudentCount",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_Gallery",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_CoursePrice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_ContactInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_BasicInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shared_Address",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_UserInRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_UserInOrganization",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_TestBankOfQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_CouseStudentMaterial",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_CourseStudent",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_CourseLector",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_CourseCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Link_CourseBrowse",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_UserRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_TestQuestionAnswer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_TestQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_StudentTestSummaryQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_StudentTestSummaryAnswer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_StudentTestSummary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Slider",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Person",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_OrganizationSetting",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_OrganizationRolePermition",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_OrganizationRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Organization",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Notification",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_LectorRate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Job",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Inquiry",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_FileRepository",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_CourseTest",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_CourseTerm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_CourseLessonItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_CourseLesson",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_ClassRoom",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Category",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_Branch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Edu_BankOfQuestion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_TimeTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_NotificationType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_License",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_GalleryItemType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_Email",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_Culture",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_CourseType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_CourseStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_CourseLessonItemTemplate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_Country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_AnswerMode",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cb_AddressType",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "System_ObjectHistory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "System_DataMigration");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_StudentCount");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_Gallery");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_CoursePrice");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_ContactInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_BasicInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shared_Address");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_UserInRole");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_UserInOrganization");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_TestBankOfQuestion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_CouseStudentMaterial");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_CourseStudent");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_CourseLector");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_CourseCategory");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Link_CourseBrowse");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_UserRole");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_TestQuestionAnswer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_TestQuestion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_StudentTestSummaryQuestion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_StudentTestSummaryAnswer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_StudentTestSummary");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Slider");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Person");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_OrganizationSetting");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_OrganizationRolePermition");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_OrganizationRole");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Organization");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Notification");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_LectorRate");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Job");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Inquiry");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_FileRepository");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_CourseTest");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_CourseTerm");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_CourseLessonItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_CourseLesson");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Course");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_ClassRoom");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Category");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_Branch");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Edu_BankOfQuestion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_TimeTable");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_NotificationType");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_License");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_GalleryItemType");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_Email");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_Culture");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_CourseType");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_CourseStatus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_CourseLessonItemTemplate");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_Country");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_AnswerMode");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cb_AddressType");
        }
    }
}
