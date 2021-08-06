using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class CreateCourseTermOrganizationStudyHourId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[CreateCourseTerm] 
@TimeFromId uniqueidentifier 
,@TimeToId uniqueidentifier 
,@ActiveFrom datetime2 
,@ActiveTo datetime2 
,@RegistrationFrom datetime2 
,@RegistrationTo datetime2 
,@Monday bit 
,@Tuesday bit 
,@Wednesday bit 
,@Thursday bit 
,@Friday bit 
,@Saturday bit 
,@Sunday bit 
,@ClassRoomId uniqueidentifier 
,@CourseId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@CoursePrice float 
,@CoursePriceSale int 
,@StudentCountMinimumStudent int 
,@StudentCountMaximumStudent int,
@OrganizationStudyHourId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_CourseTerm_id uniqueidentifier 
SET @Edu_CourseTerm_id  = NEWID() 
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
INSERT INTO Edu_CourseTerm 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, TimeFromId, TimeToId, ActiveFrom, ActiveTo, RegistrationFrom, RegistrationTo, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, ClassRoomId, CourseId, BasicInformationId, CoursePriceId, StudentCountId,OrganizationStudyHourId) VALUES 
(@Edu_CourseTerm_id, 0, 0, 1, null, @TimeFromId, @TimeToId, @ActiveFrom, @ActiveTo, @RegistrationFrom, @RegistrationTo, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, @Sunday, @ClassRoomId, @CourseId, @BasicInformationId, @CoursePriceId, @StudentCountId,@OrganizationStudyHourId); 
SELECT @Edu_CourseTerm_id AS OutGuid
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END ");
            migrationBuilder.Sql(@"ALTER  PROCEDURE [dbo].[UpdateCourseTerm]
@Id uniqueidentifier,
@TimeFromId uniqueidentifier 
,@TimeToId uniqueidentifier 
,@ActiveFrom datetime2 
,@ActiveTo datetime2 
,@RegistrationFrom datetime2 
,@RegistrationTo datetime2 
,@Monday bit 
,@Tuesday bit 
,@Wednesday bit 
,@Thursday bit 
,@Friday bit 
,@Saturday bit 
,@Sunday bit 
,@ClassRoomId uniqueidentifier 
,@BasicInformationName nvarchar(max) 
,@BasicInformationDescription nvarchar(max) 
,@CoursePrice float 
,@CoursePriceSale int 
,@StudentCountMinimumStudent int 
,@StudentCountMaximumStudent int ,
@OrganizationStudyHourId uniqueidentifier

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION

DECLARE @BasicInformationId uniqueidentifier 
SET @BasicInformationId  = (SELECT BasicInformationId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)
DECLARE @CoursePriceId uniqueidentifier 
SET @CoursePriceId  = (SELECT CoursePriceId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)
DECLARE @StudentCountId uniqueidentifier 
SET @StudentCountId  = (SELECT StudentCountId FROM Edu_CourseTerm  Where Id= @Id AND IsDeleted = 0)

Update Shared_BasicInformation SET Name = @BasicInformationName, Description = @BasicInformationDescription WHERE Id = @BasicInformationId
Update Shared_CoursePrice SET Price = @CoursePrice, Sale = @CoursePriceSale WHERE Id = @CoursePriceId
Update Shared_StudentCount SET MinimumStudent =@StudentCountMinimumStudent, MaximumStudent = @StudentCountMaximumStudent  WHERE Id = @StudentCountId
UPDATE Edu_CourseTerm  SET 
TimeFromId = @TimeFromId, 
TimeToId = @TimeToId, 
ActiveFrom = @ActiveFrom, 
ActiveTo = @ActiveTo, 
RegistrationFrom = @RegistrationFrom, 
RegistrationTo = @RegistrationTo, 
Monday = @Monday, 
Tuesday = @Tuesday, Wednesday = @Wednesday, 
Thursday = @Thursday, Friday = @Friday, Saturday = @Saturday, Sunday =@Sunday,
OrganizationStudyHourId =@OrganizationStudyHourId
WHERE Id = @Id
 
COMMIT
END TRY
BEGIN CATCH
ROLLBACK
END CATCH
END");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseTermDetail](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ct.Id, ct.ActiveFrom,ct.ActiveTo,ct.RegistrationFrom,ct.RegistrationTo, 
                                ct.ClassRoomId,ct.Monday,ct.Tuesday, ct.Wednesday, ct.Thursday, ct.Friday, ct.Saturday,
                                ct.Sunday, bi.Name,bi.Description,ct.TimeFromId,tf.Value AS TimeFromValue, ct.TimeToId,
                                tt.Value AS TimeToValue,ct.CoursePriceId,cp.Price,cp.Sale,ct.StudentCountId, 
                                sc.MaximumStudent,sc.MinimumStudent, cl.BranchId,ct.OrganizationStudyHourId
                            FROM Edu_CourseTerm AS ct
                            JOIN Shared_BasicInformation AS bi ON ct.BasicInformationId = bi.Id AND bi.IsDeleted =0
                            JOIN Cb_TimeTable AS tf ON ct.TimeFromId = tf.Id and tf.IsDeleted = 0
                            JOIN Cb_TimeTable AS tt ON ct.TimeToId = tt.Id and tt.IsDeleted = 0
                            JOIN Shared_CoursePrice AS cp ON ct.CoursePriceId = cp.Id AND cp.IsDeleted =0
                            JOIN Shared_StudentCount AS sc ON ct.StudentCountId = sc.Id and sc.IsDeleted = 0
							JOIN Edu_ClassRoom AS cl ON cl.Id = ct.ClassRoomId and cl.IsDeleted = 0
                            WHERE ct.Id = @courseTermId  AND ct.IsDeleted =0 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
