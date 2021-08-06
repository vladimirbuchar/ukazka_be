using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetOrganizationBySendMessageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].GetOrganizationBySendMessageId (@sendMessageId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_SendMessage AS ec ON o.Id = ec.OrganizationId AND ec.IsDeleted = 0
                   WHERE ec.Id = @sendMessageId  AND o.IsDeleted = 0 
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
