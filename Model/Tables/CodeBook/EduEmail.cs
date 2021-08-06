using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.CodeBook
{
    public struct EduEmailValue
    {
        public static string REGISTRATION_USER = "REGISTRATION_USER";
        public static string PASSWORD_RESET = "PASSWORD_RESET";
    }
    [Table("Cb_Email")]
    public class EduEmail : CodeBook
    {
        [Column("Subject")]
        public virtual string Subject { get; set; }
        [Column("EmailBodyHtml")]
        public virtual string EmailBodyHtml { get; set; }
        [Column("EmailBodyPlainText")]
        public virtual string EmailBodyPlainText { get; set; }
        [Column("IsHtml")]
        public virtual bool IsHtml { get; set; } = false;
        [Column("From")]
        public virtual string From { get; set; }
    }
}
