using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddCourseLessonItemAddPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddCourseLessonItem]
@Html varchar(max) 
,@CourseLessonId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max)
,@TemplateId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseItem_id uniqueidentifier 
SET @Edu_CourseItem_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
INSERT INTO Edu_CourseLessonItem 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, Html, CourseLessonId, BasicInformationId,CourseLessonItemTemplateId,Position) VALUES 
(@Edu_CourseItem_id, 0, 0, 1, null, @Html, @CourseLessonId, @BasicInformationId,@TemplateId,(SELECT ISNULL((SELECT MAX(Position) FROM Edu_CourseLessonItem WHERE IsDeleted = 0 AND CourseLessonId =@CourseLessonId),0)+1)); 
SELECT @Edu_CourseItem_id AS OutGuid
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
