using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CiourseAddLinkToCourseMaterial : Migration
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
,@CertificateId uniqueidentifier,
@AutomaticGenerateCertificate bit,
@CourseMaterialId uniqueidentifier

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
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, CourseTypeId, CourseStatusId, IsPrivateCourse, OrganizationId, BasicInformationId, CoursePriceId, StudentCountId,CertificateId,AutomaticGenerateCertificate,CourseMaterialId) VALUES 
(@Edu_Course_id, 0, 0, 1, null, @CourseTypeId, @CourseStatusId, @IsPrivateCourse, @OrganizationId, @BasicInformationId, @CoursePriceId, @StudentCountId,@CertificateId,@AutomaticGenerateCertificate,@CourseMaterialId); 

SELECT @Edu_Course_id AS OutGuid
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateCourse]
@CourseTypeId uniqueidentifier 
,@CourseStatusId uniqueidentifier 
,@IsPrivateCourse bit 
,@CourseId uniqueidentifier
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@CoursePrice float 
,@CoursePriceSale int 
,@StudentCountMinimumStudent int 
,@StudentCountMaximumStudent int 
,@CertificateId uniqueidentifier,
@AutomaticGenerateCertificate bit,
@CourseMaterialId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_course  WHERE Id =@CourseId)
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = (SELECT CoursePriceId FROM Edu_course  WHERE Id =@CourseId)
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = (SELECT StudentCountId FROM Edu_course  WHERE Id =@CourseId)

UPDATE Edu_Course SET CourseTypeId =@CourseTypeId, CourseStatusId=@CourseStatusId, IsPrivateCourse=@IsPrivateCourse, CertificateId= @CertificateId, 
CourseMaterialId =@CourseMaterialId, AutomaticGenerateCertificate =@AutomaticGenerateCertificate WHERE Id=@CourseId
UPDATE Shared_BasicInformation SET Name =@BasicInformationName, Description =@BasicInformationDescription WHERE Id= @BasicInformationId
UPDATE Shared_CoursePrice SET Price =@CoursePrice, Sale =@CoursePriceSale WHERE Id= @CoursePriceId
UPDATE Shared_StudentCount SET MinimumStudent =@StudentCountMinimumStudent, MaximumStudent =@StudentCountMaximumStudent WHERE Id= @StudentCountId
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH END");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseDetail](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.IsPrivateCourse, bi.Name, bi.Description, cp.Price, cp.Sale,
                                  c.CourseStatusId,c.CourseTypeId,
								  sc.MaximumStudent, sc.MinimumStudent, c.CertificateId,c.AutomaticGenerateCertificate,c.CourseMaterialId
								    FROM Edu_Course AS c
                            JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                            JOIN Shared_CoursePrice AS cp ON c.CoursePriceId = cp.Id AND cp.IsDeleted = 0
                            JOIN Shared_StudentCount AS sc ON c.StudentCountId = sc.Id  AND sc.IsDeleted = 0
                        WHERE c.Id = @courseId AND c.IsDeleted = 0 
                                
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
