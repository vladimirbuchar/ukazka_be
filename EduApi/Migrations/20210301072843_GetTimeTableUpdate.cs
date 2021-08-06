using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetTimeTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION GetTimeTable(@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ctd.Id,ctd.Date,ctd.IsCanceled,ctd.DayOfWeek, tf.Value AS TimeFrom, tt.Value AS TimeTo FROM Edu_CourseTermDate AS ctd 
JOIN Cb_TimeTable AS tf ON ctd.TimeFromId = tf.Id and tf.IsDeleted = 0
JOIN Cb_TimeTable AS tt ON ctd.TimeFromId = tt.Id and tt.IsDeleted = 0
WHERE ctd.CourseTermId = @courseTermId AND ctd.IsDeleted = 0
                             
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
