using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCbTimeListCobeBookValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE Cb_TimeTable SET 
Name = SystemIdentificator,
Value = SystemIdentificator
WHERE 
SystemIdentificator = 'CODEBOOK_SELECT_VALUE'
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
