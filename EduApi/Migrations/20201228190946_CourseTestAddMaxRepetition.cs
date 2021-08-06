using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CourseTestAddMaxRepetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseTestDetail](@courseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cl.Id, sbi.Name, sbi.Description, t.IsRandomGenerateQuestion,t.QuestionCountInTest,t.TimeLimit, t.DesiredSuccess, t.Id AS TestId,t.MaxRepetition FROM Edu_CourseLesson AS cl
                                           JOIN Shared_BasicInformation as sbi ON cl.BasicInformationId =  sbi.Id AND sbi.IsDeleted = 0
										   JOIN Edu_CourseTest AS t on cl.Id = t.CourseLessonId AND t.IsDeleted = 0
WHERE cl.Id =@courseLessonId AND cl.IsDeleted = 0)
");
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[AddCourseTest] 
@IsRandomGenerateQuestion bit 
,@QuestionCountInTest int 
,@TimeLimit int 
,@DesiredSuccess int 
,@CourseLessonId uniqueidentifier, 
@MaxRepetition int

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseTest_id uniqueidentifier 
SET @Edu_CourseTest_id  = NEWID() 
INSERT INTO Edu_CourseTest 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, IsRandomGenerateQuestion, QuestionCountInTest, TimeLimit, DesiredSuccess, CourseLessonId,MaxRepetition) VALUES 
(@Edu_CourseTest_id, 0, 0, 1, null, @IsRandomGenerateQuestion, @QuestionCountInTest, @TimeLimit, @DesiredSuccess, @CourseLessonId,@MaxRepetition); 
SELECT @Edu_CourseTest_id AS OutGuid

COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateCourseTest]
@IsRandomGenerateQuestion bit 
,@QuestionCountInTest int 
,@TimeLimit int 
,@DesiredSuccess int 
,@CourseLessonId uniqueidentifier 
,@MaxRepetition int
AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
 UPDATE Edu_CourseTest SET IsRandomGenerateQuestion = @IsRandomGenerateQuestion, QuestionCountInTest =@QuestionCountInTest,TimeLimit=@TimeLimit,DesiredSuccess =@DesiredSuccess, MaxRepetition =@MaxRepetition 
 WHERE CourseLessonId =@CourseLessonId


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
