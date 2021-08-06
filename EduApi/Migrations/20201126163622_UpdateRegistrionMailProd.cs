using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class UpdateRegistrionMailProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string email = "<a href =\"{activationLink}\">{activationLink}</a>";
            migrationBuilder.Sql(@"UPDATE Cb_Email 
SET EmailBodyHtml = '<p>Dobrý den,</p> děkujeme Vám za registraci v aplikaci FlexibleLMS. <p>Pro dokončení registrace  je nutné kliknout na tento odkaz " + email + "</p> <br /><br /> <p>S přáním hezkého dne</p> <p>Tým aplikace FlexibleLMS</p>'  WHERE SystemIdentificator= 'REGISTRATION_USER_cs-CZ'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
