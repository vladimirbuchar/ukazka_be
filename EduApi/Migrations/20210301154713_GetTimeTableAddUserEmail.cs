using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetTimeTableAddUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTimeTable](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ctd.Id,ctd.Date,ctd.IsCanceled,ctd.DayOfWeek, tf.Value AS TimeFrom, tt.Value AS TimeTo, csbi.Name AS ClassRoom, p.FirstName, p.LastName,p.SecondName,u.UserEmail FROM Edu_CourseTermDate AS ctd 
JOIN Cb_TimeTable AS tf ON ctd.TimeFromId = tf.Id and tf.IsDeleted = 0
JOIN Cb_TimeTable AS tt ON ctd.TimeToId = tt.Id and tt.IsDeleted = 0
JOIN Edu_ClassRoom AS c ON c.Id =ctd.ClassRoomId AND c.IsDeleted = 0
JOIN Shared_BasicInformation AS csbi ON c.BasicInformationId = csbi.Id AND csbi.IsDeleted = 0
JOIN Link_UserInOrganization AS uio ON uio.Id = ctd.UserInOrganizationId and uio.IsDeleted = 0
JOIN Edu_User AS u ON u.Id = uio.UserId AND u.IsDeleted = 0
JOIN Edu_Person AS p ON p.Id = u.PersonId AND p.IsDeleted = 0
WHERE ctd.CourseTermId = @courseTermId AND ctd.IsDeleted = 0
                             
)
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
