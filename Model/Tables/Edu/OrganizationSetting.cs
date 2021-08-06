using Model.Tables.CodeBook;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu
{
    [Table("Edu_OrganizationSetting")]
    public class OrganizationSetting : TableModel
    {
        public virtual string UserDefaultPassword { get; set; }
        public virtual DateTime LicenseChange { get; set; }
        public virtual License LicenseOld { get; set; }
        public virtual Guid LogoId { get; set; }
        public virtual string ElearningUrl { get; set; }
        public string BackgroundColor { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
        public int LessonLength { get; set; }
        public string TextColor { get; set; }
        public bool UseCustomSmtpServer { get; set; }
        public string SmtpServerUrl { get; set; }
        public string SmtpServerUserName { get; set; }
        public string SmtpServerPassword { get; set; }
        public string SmtpServerPort { get; set; }
        public string GoogleApiToken { get; set; }
    }
}