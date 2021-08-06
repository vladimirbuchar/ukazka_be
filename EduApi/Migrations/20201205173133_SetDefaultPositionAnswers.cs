using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class SetDefaultPositionAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Update Edu_BankOfQuestion SET Position = 0;
Update Edu_TestQuestion SET Position = 0;
Update Edu_TestQuestionAnswer SET Position = 0
DECLARE @OrgId uniqueidentifier

DECLARE ORG_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT DISTINCT Id 
FROM Edu_Organization WHERE IsDeleted = 0

OPEN ORG_CURSOR
FETCH NEXT FROM ORG_CURSOR INTO @OrgId
WHILE @@FETCH_STATUS = 0
BEGIN 
	DECLARE @BankId uniqueidentifier
	DECLARE @BankPosition int;
	SET @BankPosition = 1
	DECLARE BANK_OF_QUESTION_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 
	SELECT Id FROM Edu_BankOfQuestion WHERE  OrganizationId = @OrgId AND IsDeleted = 0 
	OPEN BANK_OF_QUESTION_CURSOR
	FETCH NEXT FROM BANK_OF_QUESTION_CURSOR INTO @BankId
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		DECLARE @questionId uniqueidentifier
		DECLARE @questionPosition int;
		set @questionPosition = 1
		UPDATE Edu_BankOfQuestion SET Position = @BankPosition WHERE Id = @BankId
		SET @BankPosition = @BankPosition+ 1
		--- question
		DECLARE QUESTION_CURSOR CURSOR 
			LOCAL STATIC READ_ONLY FORWARD_ONLY
				FOR 
	SELECT Id FROM Edu_TestQuestion WHERE  BankOfQuestionId = @BankId AND IsDeleted = 0 
	
	OPEN QUESTION_CURSOR
	FETCH NEXT FROM QUESTION_CURSOR INTO @questionId
	
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		DECLARE @answerId uniqueidentifier
		DECLARE @answerPosition int;
		set @answerPosition = 1
	 UPDATE Edu_TestQuestion Set Position = @questionPosition WHERE Id = @questionId
	SET @questionPosition = @questionPosition +1
	--- answer 


	DECLARE ANSWER_CURSOR CURSOR 
			LOCAL STATIC READ_ONLY FORWARD_ONLY
				FOR 
	SELECT Id FROM Edu_TestQuestionAnswer WHERE  TestQuestionId  = @questionId AND IsDeleted = 0 
	
	OPEN ANSWER_CURSOR
	FETCH NEXT FROM ANSWER_CURSOR INTO @answerId
	
	WHILE @@FETCH_STATUS = 0
	BEGIN 
	 UPDATE Edu_TestQuestionAnswer Set Position = @answerPosition WHERE Id = @answerId
	SET @answerPosition = @answerPosition +1
		FETCH NEXT FROM ANSWER_CURSOR INTO @answerId
	
	END


		CLOSE ANSWER_CURSOR
	DEALLOCATE ANSWER_CURSOR



	--- answer end
	
	FETCH NEXT FROM QUESTION_CURSOR INTO @questionId
	
	END


		CLOSE QUESTION_CURSOR
	DEALLOCATE QUESTION_CURSOR

		---question end

		FETCH NEXT FROM BANK_OF_QUESTION_CURSOR INTO @BankId
	END
	CLOSE BANK_OF_QUESTION_CURSOR
	DEALLOCATE BANK_OF_QUESTION_CURSOR
    FETCH NEXT FROM ORG_CURSOR INTO @OrgId
END
CLOSE ORG_CURSOR
DEALLOCATE ORG_CURSOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
