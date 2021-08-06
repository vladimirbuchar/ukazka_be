using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GenerateTimeTableAddLector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[GenerateTimeTable]
@CourseTermId uniqueidentifier,
@Date date,
@TimeFromId uniqueidentifier,
@TimeToId uniqueidentifier,
@DayOfWeek varchar(max),
@CourseLectorId uniqueidentifier,
@ClassRoomId uniqueidentifier


AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_id uniqueidentifier 
SET @Edu_id  = NEWID() 



INSERT INTO Edu_CourseTermDate 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Date, IsCanceled, CourseTermId,DayOfWeek,TimeFromId,TimeToId,ClassRoomId,CourseLectorId) VALUES 
(@Edu_id, 0, 0, 1, null, @Date, 0, @CourseTermId,@DayOfWeek,@TimeFromId,@TimeToId,@ClassRoomId,@CourseLectorId); 
SELECT @Edu_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
