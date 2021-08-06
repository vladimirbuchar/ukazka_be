﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateCourseLessonItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateCourseLessonItem
@Html varchar(max) 
,@CourseLessonItemId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_CourseItem WHERE Id = @CourseLessonItemId )

UPDATE Shared_BasicInformation SET Name = @BasicInformationName,Description = @BasicInformationDescription WHERE Id = @BasicInformationId
UPDATE Edu_CourseItem SET  Html =@Html WHERE Id = @CourseLessonItemId


COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
