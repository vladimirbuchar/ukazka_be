using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SaveStudentAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE SaveStudentAttendance

@studentId uniqueidentifier,
@timeTableId uniqueidentifier,
@courseTermId uniqueidentifier,
@isActive bit

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_id uniqueidentifier 
SET @Edu_id  = NEWID() 

UPDATE Edu_AttendanceStudent SET IsDeleted = 1 WHERE IsDeleted = 0 AND  CourseTermDateId = @timeTableId AND CourseStudentId =@studentId 


INSERT INTO Edu_AttendanceStudent 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CourseTermDateId,CourseStudentId,CourseTermId,IsActive) VALUES 
(@Edu_id, 0, 0, 1, null,@timeTableId, @studentId,@courseTermId,@isActive)
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
