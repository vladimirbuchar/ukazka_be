using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllBranchInOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT b.Id, b.IsMainBranch, a.CountryId, Region, City, Street, HouseNumber, ZipCode, bi.Name,cbc.Name AS CountryName,
                            bi.Description, Email, PhoneNumber, WWW    
                           FROM Edu_Branch as b
                           JOIN Shared_Address AS a on a.Id = b.AddressId AND a.IsDeleted = 0 
                           JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId AND b.IsDeleted = 0 
                           JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId AND bi.IsDeleted = 0 
						   JOIN Cb_Country as cbc ON a.CountryId = cbc.Id AND cbc.IsDeleted = 0
                            WHERE b.OrganizationId =@organizationId  
                            AND c.IsDeleted = 0
)");

            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllClassRoomInBranch](@branchId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description
                               FROM Edu_ClassRoom as c
                               JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                               WHERE c.BranchId = @branchId AND c.IsDeleted = 0
)");

            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllCourseInOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id, bi.Name FROM Edu_Course AS c
                           JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                            WHERE c.IsDeleted = 0  AND c.OrganizationId = @organizationId
)
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllCourseTermLector](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT uio.Id, p.FirstName, p.LastName,p.SecondName, l.Id AS LectorId FROM Link_CourseLector as l
                            join Link_UserInOrganization as uio ON l.UserInOrganizationId= uio.Id AND uio.IsDeleted =0 
                            join Edu_User as u ON uio.UserId = u.Id AND u.IsDeleted =0 
                            join Edu_Person as p ON u.PersonId = p.Id AND p.IsDeleted = 0	
                           WHERE l.CourseTermId = @courseTermId AND l.IsDeleted = 0 
                            
)
");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllOrganizations]()
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id,bi.Name,bi.Description,l.Priority
                            FROM Edu_Organization AS o
                            JOIN Shared_BasicInformation AS bi ON o.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                            JOIN Cb_License AS l ON o.LicenseId = l.Id AND l.IsDeleted = 0
                            WHERE o.IsDeleted = 0 
)");

            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllSliderItems]()
RETURNS TABLE  AS
RETURN 
( 
SELECT s.Id, s.Image, bi.Name,bi.Description,s.Priority
                           FROM Edu_Slider AS s
                           JOIN Shared_BasicInformation AS bi ON s.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                           WHERE s.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetAllUserInOrganization](@organizationOid uniqueidentifier)
RETURNS TABLE  AS
RETURN
(
SELECT uio.Id, p.FirstName, p.SecondName, p.LastName, u.UserEmail, orl.SystemIdentificator AS UserRole, uio.UserId
                             FROM Edu_User AS u
                             JOIN Edu_Person as p ON u.PersonId = p.Id AND p.IsDeleted = 0
                             JOIN Link_UserInOrganization AS uio ON uio.UserId = u.Id AND uio.IsDeleted = 0
                             JOIN Edu_OrganizationRole AS orl ON orl.Id = uio.OrganizationRoleId AND orl.IsDeleted =0
                             WHERE uio.OrganizationId = @organizationOid
                                     AND  u.IsDeleted = 0 AND u.IsActive = 1
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetBranchDetail](@branchId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT b.Id,b.IsMainBranch, a.CountryId,Region,City,Street,HouseNumber,ZipCode,Name,
                                Description,Email,PhoneNumber,WWW 
                            FROM Edu_Branch as b
                            JOIN Shared_Address AS a on a.Id = b.AddressId AND b.IsDeleted = 0
                            JOIN Shared_BasicInformation AS bi on bi.Id = b.BasicInformationId AND bi.IsDeleted = 0
                            JOIN Shared_ContactInformation as c on c.Id = b.ContactInformationId AND c.IsDeleted =0
                            WHERE b.Id = @branchId AND b.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetClassRoomDetail](@classRoomId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.Floor,c.MaxCapacity,bi.Name, bi.Description
                                FROM Edu_ClassRoom as c
                                JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted =0
                                WHERE c.Id = @classRoomId AND c.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseDetail](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id,c.IsPrivateCourse, bi.Name, bi.Description, cp.Price, cp.Sale,
                                  c.CourseStatusId,c.CourseTypeId  FROM Edu_Course AS c
                            JOIN Shared_BasicInformation AS bi ON c.BasicInformationId = bi.Id AND bi.IsDeleted = 0
                            JOIN Shared_CoursePrice AS cp ON c.CoursePriceId = cp.Id AND cp.IsDeleted = 0
                            JOIN Shared_StudentCount AS sc ON c.StudentCountId = sc.Id  AND sc.IsDeleted = 0
                        WHERE c.Id = @courseId AND c.IsDeleted = 0 
                                
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseLessonItemDetail](@CourseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ci.Id, ci.Html, sbi.Name, sbi.Description, ci.CourseLessonItemTemplateId, clit.SystemIdentificator AS TemplateIdentificator,fr.FileName,fr.OriginalFileName, fr.Id AS FileId, ci.Youtube
				  FROM Edu_CourseLessonItem AS ci
				  LEFT JOIN Edu_FileRepository AS fr ON ci.Id = fr.ObjectOwner AND fr.IsDeleted = 0
                  JOIN Shared_BasicInformation as sbi ON ci.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
				  JOIN Cb_CourseLessonItemTemplate AS clit ON clit.Id = ci.CourseLessonItemTemplateId AND clit.IsDeleted = 0
                  WHERE ci.Id = @CourseLessonItemId AND ci.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetCourseTermDetail](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT ct.Id, ct.ActiveFrom,ct.ActiveTo,ct.RegistrationFrom,ct.RegistrationTo, 
                                ct.ClassRoomId,ct.Monday,ct.Tuesday, ct.Wednesday, ct.Thursday, ct.Friday, ct.Saturday,
                                ct.Sunday, bi.Name,bi.Description,ct.TimeFromId,tf.Value AS TimeFromValue, ct.TimeToId,
                                tt.Value AS TimeToValue,ct.CoursePriceId,cp.Price,cp.Sale,ct.StudentCountId, 
                                sc.MaximumStudent,sc.MinimumStudent, cl.BranchId
                            FROM Edu_CourseTerm AS ct
                            JOIN Shared_BasicInformation AS bi ON ct.BasicInformationId = bi.Id AND bi.IsDeleted =0
                            JOIN Cb_TimeTable AS tf ON ct.TimeFromId = tf.Id and tf.IsDeleted = 0
                            JOIN Cb_TimeTable AS tt ON ct.TimeToId = tt.Id and tt.IsDeleted = 0
                            JOIN Shared_CoursePrice AS cp ON ct.CoursePriceId = cp.Id AND cp.IsDeleted =0
                            JOIN Shared_StudentCount AS sc ON ct.StudentCountId = sc.Id and sc.IsDeleted = 0
							JOIN Edu_ClassRoom AS cl ON cl.Id = ct.ClassRoomId and cl.IsDeleted = 0
                            WHERE ct.Id = @courseTermId  AND ct.IsDeleted =0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetLicenseByOrganization](@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT l.Id, l.Name,l.Value,
                            l.IsDefault,l.MaximumBranch,l.MaximumUser,l.MaximumCourse,
                            l.MounthPrice,l.OneYearSale,l.SendCourseInquiry,
                            l.CreatePrivateCourse,l.Priority
                           FROM Cb_License AS l
                           JOIN Edu_Organization AS o ON l.Id = o.LicenseId AND l.IsDeleted = 0 
                           WHERE  o.Id = @organizationId AND o.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyNewNotification](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT n.Id,nt.SystemIdentificator AS NotificationIdentificator ,n.ObjectId,n.IsNew,n.AddDate FROM Edu_Notification  AS n
JOIN Cb_NotificationType AS nt ON n.NotificationTypeId = nt.Id AND nt.IsDeleted = 0
WHERE n.UserId =@userId AND n.IsDeleted =0 AND n.IsNew = 1
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyNotification](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT n.Id,nt.SystemIdentificator AS NotificationIdentificator ,n.ObjectId,n.IsNew,n.AddDate FROM Edu_Notification  AS n
JOIN Cb_NotificationType AS nt ON n.NotificationTypeId = nt.Id AND nt.IsDeleted = 0
WHERE n.UserId = @userId AND n.IsDeleted = 0 
)");


            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetMyOrganization](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id, sbi.Name, eor.SystemIdentificator AS OrganizationRole, luio.Id AS UserInOrganizationRoleId
                             FROM Link_UserInOrganization AS luio
                             JOIN Edu_Organization AS o  ON o.Id = luio.OrganizationId AND o.IsDeleted = 0
                             JOIN Shared_BasicInformation as sbi on o.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
                             JOIN Edu_OrganizationRole as eor on luio.OrganizationRoleId = eor.Id AND eor.IsDeleted = 0
                             WHERE  luio.UserId =@userId AND  luio.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationAddress](@organizationOid uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT a.Id,a.CountryId,a.Region,a.City,a.Street, a.HouseNumber,a.ZipCode,a.AddressTypeId, at.SystemIdentificator AS AddressTypeIdentificator
                            FROM  Shared_Address AS a
                            JOIN Cb_AddressType AS at ON at.Id =  a.AddressTypeId AND at.IsDeleted = 0
                            WHERE a.OrganizationId = @organizationOid AND a.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByBankOfQuestion](@BankOfQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_BankOfQuestion AS boq ON o.Id = boq.OrganizationId AND boq.IsDeleted = 0
                   WHERE boq.Id = @BankOfQuestionId  AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByBranch](@branchId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT  o.Id
                           FROM Edu_Organization AS o
                           JOIN Edu_Branch AS b ON b.OrganizationId = o.Id AND b.IsDeleted = 0
                           WHERE  b.Id = @branchId AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByClassRoom](@classRoomId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Branch as b ON b.OrganizationId = o.Id AND b.IsDeleted = 0
                           JOIN Edu_ClassRoom as c ON c.BranchId = b.Id AND c.IsDeleted = 0
                           WHERE c.Id = @classRoomId AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourse](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                                  FROM Edu_Organization AS o
                            JOIN Edu_Course AS c ON o.Id = c.OrganizationId AND c.IsDeleted =0
                            WHERE c.Id = @courseId AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLesson](@courseLessonId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                                  FROM Edu_Organization AS o
                            JOIN Edu_Course AS c ON o.Id = c.OrganizationId AND c.IsDeleted = 0
							JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId AND cl.IsDeleted = 0
                            WHERE cl.Id = @courseLessonId   AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseLessonItem](@courseLessonItemId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_Course AS c ON o.Id = c.OrganizationId AND c.IsDeleted = 0
                   JOIN Edu_CourseLesson AS cl  ON  c.Id  = cl.CourseId AND cl.IsDeleted = 0
                   JOIN Edu_CourseLessonItem AS ci ON cl.Id = ci.CourseLessonId AND ci.IsDeleted = 0
                   WHERE ci.Id = @courseLessonItemId AND o.IsDeleted =0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByCourseTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Course as c ON o.Id = c.OrganizationId AND c.IsDeleted = 0
                           JOIN Edu_CourseTerm as t ON c.Id = t.CourseId AND t.IsDeleted =0
                           WHERE t.Id = @courseTermId AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByStudent](@studentId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                           FROM Edu_Organization as o
                           JOIN Edu_Course as c ON o.Id = c.OrganizationId AND c.IsDeleted = 0
                           JOIN Edu_CourseTerm as t ON c.Id = t.CourseId AND t.IsDeleted = 0
						   JOIN Link_CourseStudent AS cs ON cs.CourseTermId = t.id AND cs.IsDeleted = 0
                           WHERE cs.Id = @studentId AND o.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetOrganizationByUserInOrganization](@userInOrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id,o.IsDeleted,o.IsSystemObject,o.IsChanged,o.SystemIdentificator,o.BasicInformationId,
                                  o.LicenseId,o.CanSendCourseInquiry  
                            FROM Link_UserInOrganization AS uio 
                            JOIN Edu_Organization AS o ON o.Id = uio.OrganizationId AND o.IsDeleted = 0
                            WHERE uio.Id = @userInOrganizationId AND uio.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationIdByAnswer](@answerId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_BankOfQuestion AS boq ON o.Id = boq.OrganizationId AND boq.IsDeleted = 0
				   JOIN Edu_TestQuestion AS q on q.BankOfQuestionId = boq.Id AND q.IsDeleted =0
				   JOIN Edu_TestQuestionAnswer AS tqa on tqa.TestQuestionId = q.Id AND tqa.IsDeleted = 0
                   WHERE tqa.Id = @answerId  AND o.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationIdByQuestion](@BankOfQuestionId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT o.Id
                   FROM Edu_Organization AS o
                   JOIN Edu_BankOfQuestion AS boq ON o.Id = boq.OrganizationId AND boq.IsDeleted = 0
				   JOIN Edu_TestQuestion AS q on q.BankOfQuestionId = boq.Id AND q.IsDeleted = 0
                   WHERE q.Id = @BankOfQuestionId   AND o.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER  FUNCTION [dbo].[GetOrganizationSetting](@OrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT OrganizationId,UserDefaultPassword, eo.LicenseId  from Edu_OrganizationSetting as eos
join Edu_Organization  eo ON eos.OrganizationId = eo.Id and eo.IsDeleted =0 
WHERE eos.IsDeleted= 0 AND OrganizationId =@OrganizationId
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentCourse](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT c.Id, sbi.Name AS CourseName, ct.ActiveFrom, ct.ActiveTo,ttf.Value AS TimeFrom, ttt.Value AS TimeTo, lcs.UserId, csbi.Name AS ClassRoom, bsbi.Name AS  BranchName,
ct.Monday,ct.Thursday,ct.Wednesday,ct.Tuesday, ct.Friday, ct.Saturday, ct.Sunday,osbi.Name AS OrganizationName,ct.Id AS TermId
  FROM Edu_Course AS c
  JOIN Shared_BasicInformation as sbi ON sbi.Id = c.BasicInformationId  AND sbi.IsDeleted = 0
  JOIN Edu_CourseTerm AS ct ON ct.CourseId =  c.Id  and ct.IsDeleted = 0
  JOIN Cb_TimeTable AS ttf on  ct.TimeFromId = ttf.Id and ttf.IsDeleted = 0
  JOIN Cb_TimeTable AS ttt on  ct.TimeToId = ttt.Id and ttt.IsDeleted = 0
  JOIN Link_CourseStudent AS lcs ON lcs.CourseTermId = ct.Id and lcs.IsDeleted = 0
  JOIN Edu_ClassRoom AS cl ON ct.ClassRoomId = cl.Id AND cl.IsDeleted = 0
  JOIN Shared_BasicInformation AS  csbi ON csbi.Id = cl.BasicInformationId  AND csbi.IsDeleted = 0
  JOIN Edu_Branch AS eb ON cl.BranchId = eb.Id AND eb.IsDeleted = 0
  JOIN Shared_BasicInformation AS  bsbi ON bsbi.Id = eb.BasicInformationId AND bsbi.IsDeleted = 0
  JOIN Edu_Organization AS eo ON eb.OrganizationId = eo.Id AND eo.IsDeleted = 0
  JOIN Shared_BasicInformation AS  osbi ON osbi.Id = eo.BasicInformationId AND osbi.IsDeleted = 0
  JOIN Link_UserInOrganization AS uio ON lcs.UserId = uio.Id AND uio.IsDeleted =0
  WHERE c.IsDeleted = 0  AND ct.ActiveTo >= SYSDATETIME() AND uio.UserId =@userId
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentQuestion](@studentTestSummaryId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT stsq.Id, tq.Question, stsq.Score, stsq.IsTrue,am.SystemIdentificator AS AnswerMode, tq.Id  AS QuestionId, stsq.IsAutomaticEvaluate FROM Edu_StudentTestSummaryQuestion AS stsq
JOIN Edu_TestQuestion AS tq ON tq.Id = stsq.TestQuestionId AND tq.IsDeleted = 0
JOIN Cb_AnswerMode AS am ON am.Id = tq.AnswerModeId AND am.IsDeleted = 0

 WHERE stsq.StudentTestSummaryId  = @studentTestSummaryId AND stsq.IsDeleted = 0

)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetStudentsInTerm](@courseTermId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT cs.Id, p.FirstName, p.LastName,p.SecondName, cs.UserId AS StudentId,u.UserEmail
                            FROM Link_CourseStudent AS cs
							JOIN Link_UserInOrganization as luin ON  cs.UserId = luin.Id AND luin.IsDeleted = 0
                            JOIN Edu_User AS u ON luin.UserId = u.Id AND u.IsDeleted = 0
                             JOIN Edu_Person AS p ON p.Id = u.PersonId AND p.IsDeleted = 0
                            WHERE cs.CourseTermId = @courseTermId AND cs.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetTermInCourse](@courseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT t.Id,t.CourseId, ttTo.Value AS TimeTo, ttFrom.Value AS TimeFrom, cbi.Name AS ClassRoom, bsi.Name AS Branch,
t.ActiveFrom, t.ActiveTo, t.Friday,t.Monday,t.Thursday,t.Wednesday,t.Tuesday,t.Sunday,t.Saturday
                           FROM Edu_CourseTerm AS t
						   LEFT JOIN Cb_TimeTable AS ttTo ON t.TimeToId  = ttTo.Id   AND ttTo.IsDeleted = 0
						   LEFT JOIN Cb_TimeTable AS ttFrom ON t.TimeFromId  = ttFrom.Id AND ttFrom.IsDeleted = 0
						   LEFT JOIN Edu_ClassRoom AS c ON t.ClassRoomId = c.Id AND c.IsDeleted = 0
						   LEFT JOIN Shared_BasicInformation AS cbi ON c.BasicInformationId =  cbi.Id AND cbi.IsDeleted =0
						   LEFT JOIN Edu_Branch AS b ON b.Id = c.BranchId  AND b.IsDeleted = 0
						   LEFT JOIN Shared_BasicInformation AS bsi ON b.BasicInformationId = bsi.Id AND bsi.IsDeleted = 0
						   

                           WHERE t.CourseId = @courseId AND t.IsDeleted =0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserAddress](@personOid uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT a.Id,a.CountryId,a.Region,a.City,a.Street, a.HouseNumber,a.ZipCode,a.AddressTypeId, at.SystemIdentificator AS AddressTypeIdentificator
                            FROM  Shared_Address AS a
                            JOIN Cb_AddressType AS at ON at.Id =  a.AddressTypeId AND at.IsDeleted = 0
                            WHERE a.PersonId = @personOid AND a.IsDeleted = 0
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserCourseBrowse](@UserId uniqueidentifier,@CouurseId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT CourseLessonItemId, ecl.Type AS ItemType  FROM Link_CouseStudentMaterial  AS lcsm
JOIN Edu_CourseLessonItem AS ecli ON ecli.Id = lcsm.CourseLessonItemId AND ecli.IsDeleted = 0
JOIN Edu_CourseLesson AS ecl ON ecl.Id = ecli.CourseLessonId AND ecl.IsDeleted = 0
JOIN Cb_CourseLessonItemTemplate AS clit ON clit.Id = ecli.CourseLessonItemTemplateId AND clit.IsDeleted = 0
WHERE lcsm.IsDeleted = 0 AND UserId =@UserId AND lcsm.CourseId = @CouurseId
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserDetail](@userId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id, u.UserEmail, p.FirstName, p.SecondName, p.LastName, p.Id AS PersonId
                             FROM Edu_User AS u
                             JOIN Edu_Person AS p ON u.PersonId =p.Id AND p.IsDeleted = 0
                             WHERE u.Id = @userId AND u.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserDetailByEmail](@userEmail varchar(max))
RETURNS TABLE  AS
RETURN 
( 
SELECT u.Id, u.UserEmail, p.FirstName, p.SecondName, p.LastName, p.Id AS PersonId
                             FROM Edu_User AS u
                             JOIN Edu_Person AS p ON u.PersonId = p.Id AND p.IsDeleted = 0
                             WHERE u.UserEmail = @userEmail AND u.IsDeleted = 0 
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserOrganizationRole](@userId uniqueidentifier,@organizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT eor.Id, eor.SystemIdentificator, uio.Id AS UioId
                           FROM Link_UserInOrganization AS uio
                           JOIN Edu_OrganizationRole AS eor ON uio.OrganizationRoleId = eor.Id AND eor.IsDeleted = 0
                           WHERE  uio.UserId =@userId and uio.OrganizationId = @organizationId  AND  uio.IsDeleted = 0 
                                
)");
            migrationBuilder.Sql(@"ALTER FUNCTION [dbo].[GetUserOrganizationRoleDetail](@userInOrganizationId uniqueidentifier)
RETURNS TABLE  AS
RETURN 
( 
SELECT  OrganizationRoleId
  FROM Link_UserInOrganization WHERE Id = @userInOrganizationId AND IsDeleted = 0
)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
