using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetMailAddSystemIdentificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMail](@Identificator varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT [Subject]
      ,EmailBodyHtml
      ,EmailBodyPlainText
      ,IsHtml
      ,[From],
	  SystemIdentificator
	  FROM Cb_Email WHERE IsDeleted = 0 AND SystemIdentificator = @Identificator OR  SystemIdentificator LIKE'%'+@Identificator
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
