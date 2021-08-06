using Microsoft.EntityFrameworkCore.Migrations;

namespace EduApi.Migrations
{
    public partial class AddPasswordResetEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string link = "<a href = \"{passwordResetLink}\">{passwordResetLink}</a>";
            migrationBuilder.Sql(@"INSERT INTO Cb_Email (Id,IsDeleted,IsSystemObject,IsChanged,SystemIdentificator,Subject,EmailBodyHtml,EmailBodyPlainText,IsHtml,IsDefault,Name,Priority,Value,IsActive)
VALUES
(NEWID(),0,1,1,'PASSWORD_RESET_cs','Zapomenuté heslo','<p>Dobrý den,</p><p>Na Vašem účtu jsme zaregistrovali požadavek na změnu hesla. Pro nastavení nového hesla klikněte na tento odkaz " + link + ". Pokud jste o změnu hesla nežádali tento email ignorujte.</p> <p>S přáním hezkého dne</p><br /> <p>Tým aplikace FlexibleLMS</p>','Dobrý den,Na Vašem účtu jsme zaregistrovali požadavek na změnu hesla. Pro nastavení nového hesla klikněte na tento odkaz {passwordResetLink}. Pokud jste o změnu hesla nežádali tento email ignorujte. S přáním hezkého dne Tým aplikace FlexibleLMS',1,0,null,0,null,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
