using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CheckOrganizationUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Edu_OrganizationSetting SET ElearningUrl = NEWID() WHERE ElearningUrl IS NULL OR ElearningUrl = '' ");
            migrationBuilder.AlterColumn<string>(
                name: "ElearningUrl",
                table: "Edu_OrganizationSetting",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
            migrationBuilder.Sql(@"CREATE  FUNCTION CheckOrganizationUrl (@organizationUrl varchar(max), @organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT COUNT(*) AS RowsCount  FROM Edu_OrganizationSetting  WHERE ElearningUrl = @organizationUrl AND OrganizationId != @organizationId
)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ElearningUrl",
                table: "Edu_OrganizationSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
