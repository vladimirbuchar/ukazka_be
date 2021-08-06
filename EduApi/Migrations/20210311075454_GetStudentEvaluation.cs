using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class GetStudentEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION GetStudentEvaluation(@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT se.Id,se.Date,se.Evaluation, p.FirstName, p.LastName, p.SecondName, u.UserEmail FROM Edu_StudentEvaluation AS  se
JOIN Link_UserInOrganization AS uio ON se.UserInOrganizationId = uio.Id AND uio.IsDeleted = 0
JOIN Edu_User AS u on u.Id = uio.UserId AND u.IsDeleted = 0
JOIn Edu_Person AS p on u.PersonId = p.Id AND p.IsDeleted = 0
WHERE se.CourseTermId = @courseTermId AND se.IsDeleted = 0
)");
            migrationBuilder.Sql(@"CREATE  PROCEDURE AddStudentEvaluation
@evaluation nvarchar(max)  
,@userInOrganizationId uniqueidentifier 
,@courseTermId uniqueidentifier 

AS 
BEGIN 
SET NOCOUNT ON; 
BEGIN TRY
BEGIN TRANSACTION
DECLARE @Edu_id uniqueidentifier 
SET @Edu_id  = NEWID() 




INSERT INTO Edu_StudentEvaluation 
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, UserInOrganizationId, Date, Evaluation,CourseTermId) VALUES 
(@Edu_id, 0, 0, 1, null, @userInOrganizationId, SYSDATETIME(), @evaluation,@courseTermId); 
SELECT @Edu_id AS OutGuid

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
