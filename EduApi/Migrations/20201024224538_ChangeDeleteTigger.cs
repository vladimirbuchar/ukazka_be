using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class ChangeDeleteTigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_AddressType] 
ON [dbo].[Cb_AddressType] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_AddressType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_AddressType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_AddressType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_AddressType', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_AnswerMode] 
ON [dbo].[Cb_AnswerMode] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_AnswerMode AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_AnswerMode AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_AnswerMode AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_AnswerMode', 'DELETE', SYSDATETIME(), null); 

END 
");

            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_Country] 
ON [dbo].[Cb_Country] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_Country AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_Country AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_Country AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_Country', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_CourseStatus] 
ON [dbo].[Cb_CourseStatus] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_CourseStatus AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_CourseStatus AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_CourseStatus AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_CourseStatus', 'DELETE', SYSDATETIME(), null); 

END 
");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_CourseType] 
ON [dbo].[Cb_CourseType] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_CourseType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_CourseType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_CourseType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_CourseType', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_Culture] 
ON [dbo].[Cb_Culture] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_Culture AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_Culture AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_Culture AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_Culture', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_Email] 
ON [dbo].[Cb_Email] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_Email AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_Email AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_Email AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_Email', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_GalleryItemType] 
ON [dbo].[Cb_GalleryItemType] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_GalleryItemType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_GalleryItemType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_GalleryItemType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_GalleryItemType', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_License] 
ON [dbo].[Cb_License] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_License AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_License AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_License AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_License', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_NotificationType] 
ON [dbo].[Cb_NotificationType] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_NotificationType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_NotificationType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_NotificationType AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_NotificationType', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Cb_TimeTable] 
ON [dbo].[Cb_TimeTable] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Cb_TimeTable AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Cb_TimeTable AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Cb_TimeTable AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Cb_TimeTable', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_BankOfQuestion] 
ON [dbo].[Edu_BankOfQuestion] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_BankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_BankOfQuestion', 'DELETE', SYSDATETIME(), null); 

END ");

            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Branch] 
ON [dbo].[Edu_Branch] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Branch AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Branch AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Branch AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Branch', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Category] 
ON [dbo].[Edu_Category] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Category AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Category AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Category AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Category', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_ClassRoom] 
ON [dbo].[Edu_ClassRoom] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_ClassRoom AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_ClassRoom AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_ClassRoom AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_ClassRoom', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Course] 
ON [dbo].[Edu_Course] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Course AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Course AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Course AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Course', 'DELETE', SYSDATETIME(), null); 

END 
");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_CourseLesson] 
ON [dbo].[Edu_CourseLesson] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_CourseLesson AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_CourseLesson AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_CourseLesson AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_CourseLesson', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_CourseLessonItem] 
ON [dbo].[Edu_CourseLessonItem] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_CourseLessonItem AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_CourseLessonItem AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_CourseLessonItem AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_CourseLessonItem', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_CourseRate] 
ON [dbo].[Edu_CourseRate] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_CourseRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_CourseRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_CourseRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_CourseRate', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_CourseTerm] 
ON [dbo].[Edu_CourseTerm] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_CourseTerm AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_CourseTerm AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_CourseTerm AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_CourseTerm', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_CourseTest] 
ON [dbo].[Edu_CourseTest] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_CourseTest AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_CourseTest AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_CourseTest AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_CourseTest', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_FileRepository] 
ON [dbo].[Edu_FileRepository] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_FileRepository AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_FileRepository AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_FileRepository AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_FileRepository', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Inquiry] 
ON [dbo].[Edu_Inquiry] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Inquiry AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Inquiry AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Inquiry AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Inquiry', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Job] 
ON [dbo].[Edu_Job] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Job AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Job AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Job AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Job', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_LectorRate] 
ON [dbo].[Edu_LectorRate] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_LectorRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_LectorRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_LectorRate AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_LectorRate', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Notification] 
ON [dbo].[Edu_Notification] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Notification AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Notification AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Notification AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Notification', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Organization] 
ON [dbo].[Edu_Organization] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Organization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Organization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
DELETE FROM Shared_BasicInformation WHERE Id = (SELECT deleted.BasicInformationId FROM deleted)
DELETE FROM Shared_ContactInformation WHERE Id = (SELECT deleted.ContactInformationId FROM deleted)
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Organization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Organization', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_OrganizationRole] 
ON[dbo].[Edu_OrganizationRole]
INSTEAD OF DELETE
AS
BEGIN
SET NOCOUNT ON;
            DECLARE @oldData XML
            SET @oldData = (
            SELECT * FROM Edu_OrganizationRole AS u
            INNER JOIN deleted AS d
ON u.Id = d.Id
WHERE u.Id = d.Id
for xml path(''), root('Root'), binary base64
)
                DECLARE @objectId uniqueidentifier
                SET @objectId = (
                SELECT u.Id FROM Edu_OrganizationRole AS u
                INNER JOIN deleted AS d
ON u.Id = d.Id
WHERE u.Id = d.Id
) 
UPDATE u SET u.IsDeleted = 1
FROM Edu_OrganizationRole AS u
INNER JOIN deleted AS d
ON u.Id = d.Id AND u.IsSystemObject = 0
INSERT INTO System_ObjectHistory
(Id, IsDeleted, IsSystemObject, IsChanged, SystemIdentificator, ObjectId, OldValue, NewValue, ObjectType, EventType, ActionTime, UserId)

VALUES
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_OrganizationRole', 'DELETE', SYSDATETIME(), null);

            END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_OrganizationRolePermition] 
ON [dbo].[Edu_OrganizationRolePermition] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_OrganizationRolePermition AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_OrganizationRolePermition AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_OrganizationRolePermition AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_OrganizationRolePermition', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Person] 
ON [dbo].[Edu_Person] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Person AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Person AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
DECLARE @result  uniqueidentifier; 
DECLARE MY_CURSOR CURSOR 
LOCAL STATIC READ_ONLY FORWARD_ONLY 
FOR 
SELECT Id FROM Shared_Address WHERE PersonId = (SELECT deleted.Id FROM deleted) 
OPEN MY_CURSOR 
FETCH NEXT FROM MY_CURSOR INTO @result 
WHILE @@FETCH_STATUS = 0 
BEGIN 
DELETE FROM Shared_Address WHERE Id = @result 
FETCH NEXT FROM MY_CURSOR INTO @result 
END 
CLOSE MY_CURSOR 
DEALLOCATE MY_CURSOR 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Person AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Person', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_Slider] 
ON [dbo].[Edu_Slider] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_Slider AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_Slider AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_Slider AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_Slider', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_StudentTestSummary] 
ON [dbo].[Edu_StudentTestSummary] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_StudentTestSummary AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_StudentTestSummary AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_StudentTestSummary AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_StudentTestSummary', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_TestQuestion] 
ON [dbo].[Edu_TestQuestion] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_TestQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_TestQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_TestQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_TestQuestion', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_TestQuestionAnswer] 
ON [dbo].[Edu_TestQuestionAnswer] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_TestQuestionAnswer AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_TestQuestionAnswer AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_TestQuestionAnswer AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_TestQuestionAnswer', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_User] 
ON [dbo].[Edu_User] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_User AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_User AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
DELETE FROM Edu_Person WHERE Id = (SELECT deleted.PersonId FROM deleted)
UPDATE u SET u.IsActive = 0,u.UserEmail = u.UserEmail+''+CONVERT(varchar(255), NEWID())
                              FROM Edu_User AS u
                              INNER JOIN deleted AS d
                              ON u.Id = d.Id AND u.IsSystemObject = 0 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_User AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_User', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Edu_UserRole] 
ON [dbo].[Edu_UserRole] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Edu_UserRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Edu_UserRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Edu_UserRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Edu_UserRole', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_CourseCategory] 
ON [dbo].[Link_CourseCategory] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_CourseCategory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_CourseCategory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_CourseCategory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_CourseCategory', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_CourseLector] 
ON [dbo].[Link_CourseLector] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_CourseLector AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_CourseLector AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_CourseLector AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_CourseLector', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_CourseStudent] 
ON [dbo].[Link_CourseStudent] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_CourseStudent AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_CourseStudent AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_CourseStudent AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_CourseStudent', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_TestBankOfQuestion] 
ON [dbo].[Link_TestBankOfQuestion] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_TestBankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_TestBankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_TestBankOfQuestion AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_TestBankOfQuestion', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_UserInOrganization] 
ON [dbo].[Link_UserInOrganization] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_UserInOrganization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_UserInOrganization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_UserInOrganization AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)
VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_UserInOrganization', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Link_UserInRole] 
ON [dbo].[Link_UserInRole] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Link_UserInRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Link_UserInRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Link_UserInRole AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Link_UserInRole', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_Address] 
ON [dbo].[Shared_Address] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_Address AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_Address AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_Address AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_Address', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_BasicInformation] 
ON [dbo].[Shared_BasicInformation] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_BasicInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_BasicInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_BasicInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_BasicInformation', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_ContactInformation] 
ON [dbo].[Shared_ContactInformation] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_ContactInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_ContactInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_ContactInformation AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_ContactInformation', 'DELETE', SYSDATETIME(), null); 

END ");

            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_CoursePrice] 
ON [dbo].[Shared_CoursePrice] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_CoursePrice AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_CoursePrice AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_CoursePrice AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_CoursePrice', 'DELETE', SYSDATETIME(), null); 

END 
");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_Gallery] 
ON [dbo].[Shared_Gallery] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_Gallery AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_Gallery AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_Gallery AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_Gallery', 'DELETE', SYSDATETIME(), null); 

END 
");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_Shared_StudentCount] 
ON [dbo].[Shared_StudentCount] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM Shared_StudentCount AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM Shared_StudentCount AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM Shared_StudentCount AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'Shared_StudentCount', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_System_DataMigration] 
ON [dbo].[System_DataMigration] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM System_DataMigration AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM System_DataMigration AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM System_DataMigration AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'System_DataMigration', 'DELETE', SYSDATETIME(), null); 

END ");
            migrationBuilder.Sql(@"ALTER TRIGGER [dbo].[SetIsDeleted_System_ObjectHistory] 
ON [dbo].[System_ObjectHistory] 
INSTEAD OF DELETE 
AS 
BEGIN 
SET NOCOUNT ON; 
DECLARE @oldData XML 
SET @oldData = ( 
SELECT * FROM System_ObjectHistory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
for xml path(''), root('Root'), binary base64 
) 
DECLARE @objectId uniqueidentifier 
SET @objectId = ( 
SELECT u.Id FROM System_ObjectHistory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id 
WHERE u.Id = d.Id 
) 
UPDATE u SET u.IsDeleted = 1 
FROM System_ObjectHistory AS u 
INNER JOIN deleted AS d 
ON u.Id = d.Id AND u.IsSystemObject = 0 
INSERT INTO System_ObjectHistory 
(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,ObjectId,OldValue,NewValue,ObjectType,EventType,ActionTime,UserId)

VALUES 
(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, 'System_ObjectHistory', 'DELETE', SYSDATETIME(), null); 

END ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
