using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateCourseAddOutGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateCourse] 
@CourseTypeId uniqueidentifier 
,@CourseStatusId uniqueidentifier 
,@IsPrivateCourse bit 
,@OrganizationId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@CoursePrice float 
,@CoursePriceSale int 
,@StudentCountMinimumStudent int 
,@StudentCountMaximumStudent int 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_Course_id uniqueidentifier 
SET @Edu_Course_id  = NEWID() 
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = NEWID(); 
INSERT INTO Shared_BasicInformation (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Name,Description) VALUES 
(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = NEWID(); 
INSERT INTO Shared_CoursePrice (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,Price,Sale) VALUES 
(@CoursePriceId,0,0,1,null,@CoursePrice,@CoursePriceSale);
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = NEWID(); 
INSERT INTO Shared_StudentCount (Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator,MinimumStudent,MaximumStudent) VALUES 
(@StudentCountId,0,0,1,null,@StudentCountMinimumStudent,@StudentCountMaximumStudent);
INSERT INTO Edu_Course 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CourseTypeId, CourseStatusId, IsPrivateCourse, OrganizationId, BasicInformationId, CoursePriceId, StudentCountId) VALUES 
(@Edu_Course_id, 0, 0, 1, null, @CourseTypeId, @CourseStatusId, @IsPrivateCourse, @OrganizationId, @BasicInformationId, @CoursePriceId, @StudentCountId); 

SELECT @Edu_Course_id AS OutGuid
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
