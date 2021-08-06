using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLessonAddType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddCourseLesson] 
@CourseId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@Type nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseLesson_id uniqueidentifier 
SET @Edu_CourseLesson_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_CourseLesson 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CourseId, BasicInformationId,Type) VALUES 
(@Edu_CourseLesson_id, 0, 0, 1, null, @CourseId, @BasicInformationId,@Type); 
SELECT @Edu_CourseLesson_id AS OutGuid

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
