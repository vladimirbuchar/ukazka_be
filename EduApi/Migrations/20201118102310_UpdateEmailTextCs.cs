using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateEmailTextCs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string link = "<a href =\"{ activationLink}\">{activationLink}</a>";
            migrationBuilder.Sql(@"UPDATE Cb_Email SET 
SystemIdentificator = 'REGISTRATION_USER_cs',
Subject = 'Děkujeme Vám za registraci',
EmailBodyHtml = '<p>Dobrý den,</p> děkujeme Vám za registraci v aplikaci FlexibleLMS. <p>Pro dokončení registrace  je nutné kliknout na tento odkaz " + link + @"</p> <br /><br /> <p>S přáním hezkého dne</p> <p>Tým aplikace FlexibleLMS</p>',
EmailBodyPlainText = 'Dobrý den, děkujeme Vám za registraci v aplikaci FlexibleLMS. Pro dokončení registrace je nutné kliknout na tento odkaz {activationLink} S přáním hezkého dne Tým aplikace FlexibleLMS',
[From] =  'info@flexiblelms.com'

WHERE SystemIdentificator = 'REGISTRATION_USER_cs-CZ' or SystemIdentificator = 'REGISTRATION_USER_cs'
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
