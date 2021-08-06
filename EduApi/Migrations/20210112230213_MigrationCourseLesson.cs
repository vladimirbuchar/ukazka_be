using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class MigrationCourseLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DECLARE @OrganizationId uniqueidentifier
DECLARE @Name varchar(max)
DECLARE @CourseId uniqueidentifier

DECLARE COURSE_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT sbi.Name, c.OrganizationId,c.Id FROM Edu_Course AS c
JOIN Shared_BasicInformation AS sbi ON c.BasicInformationId = sbi.Id AND sbi.IsDeleted = 0
WHERE c.IsDeleted =0

OPEN COURSE_CURSOR
FETCH NEXT FROM COURSE_CURSOR INTO @Name,@OrganizationId,@CourseId
WHILE @@FETCH_STATUS = 0
BEGIN 
DECLARE @id uniqueidentifier 
DECLARE @sbi_id uniqueidentifier 
   SET @id  = NEWID() 
  SET @sbi_id  = NEWID() 
  INSERT INTO Shared_BasicInformation(Id,IsDeleted,IsChanged,SystemIdentificator,Name,Description,IsActive,CultureId,IsSystemObject) VALUES
  (@sbi_id,0,1,null,@Name,'',1,null,0)
  INSERT INTO Edu_CourseMaterial(Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,IsActive,BasicInformationId,OrganizationId)
	VALUES                     (@id,0,0,1,null,1,@sbi_id,@OrganizationId);
	UPDATE Edu_CourseLesson SET CourseMaterialId =@id WHERE CourseId = @CourseId
    FETCH NEXT FROM COURSE_CURSOR INTO @Name,@OrganizationId,@CourseId
END
CLOSE COURSE_CURSOR
DEALLOCATE COURSE_CURSOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
