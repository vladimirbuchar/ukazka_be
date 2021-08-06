using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AnswerModeNewValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'YES_NO_TRUE_YES', 'YES_NO_TRUE_YES', 'YES_NO_TRUE_YES',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'YES_NO_TRUE_NO', 'YES_NO_TRUE_NO', 'YES_NO_TRUE_NO',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_ONE_IMAGE', 'SELECT_ONE_IMAGE', 'SELECT_ONE_IMAGE',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_ONE_AUDIO', 'SELECT_ONE_AUDIO', 'SELECT_ONE_AUDIO',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_ONE_VIDEO', 'SELECT_ONE_VIDEO', 'SELECT_ONE_VIDEO',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_MANY_IMAGE', 'SELECT_MANY_IMAGE', 'SELECT_MANY_IMAGE',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_MANY_AUDIO', 'SELECT_MANY_AUDIO', 'SELECT_MANY_AUDIO',0,0,1);
INSERT INTO Cb_AnswerMode (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Name,Value,IsDefault,Priority,IsActive) VALUES
(NEWID(),0,1,1, 'SELECT_MANY_VIDEO', 'SELECT_MANY_VIDEO', 'SELECT_MANY_VIDEO',0,0,1);
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
