using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetAllChatItemAddUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllChatItem] (@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ec.Id,ec.Text,ec.ParentId,ec.UserId, Date, ep.AvatarUrl, ep.FirstName, ep.LastName, ep.SecondName
FROM Edu_Chat AS ec
JOIN Edu_User AS eu ON ec.UserId = eu.Id 
JOIN Edu_Person AS ep ON ep.Id = eu.PersonId 
WHERE  ec.CourseTermId = @courseTermId AND ec.IsDeleted =0
)
");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
