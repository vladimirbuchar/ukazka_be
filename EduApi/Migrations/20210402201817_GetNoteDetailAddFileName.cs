using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetNoteDetailAddFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetNoteDetail](@noteId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT en.Id,en.Text, nt.Value, en.NoteName, en.FileName FROM Edu_Note  AS en
JOIN Cb_NoteType AS nt ON en.NoteTypeId = nt.Id AND nt.IsDefault = 0
WHERE en.Id = @noteId and en.IsDeleted = 0
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
