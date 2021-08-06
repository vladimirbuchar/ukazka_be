using System;

namespace Model.Functions.UserInOrganization
{
    public class GetOrganizationSetting : SqlFunction
    {
        public Guid OrganizationId { get; set; }
        public string UserDefaultPassword { get; set; }
        public Guid LicenseId { get; set; }
        public Guid DefaultCulture { get; set; }
        public string ElearningUrl { get; set; }
        public bool FacebookLogin { get; set; }
        public bool GoogleLogin { get; set; }
        public bool PasswordReset { get; set; }
        public bool Registration { get; set; }
        public int LessonLength { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
        public Guid BackgroundImage { get; set; }
        public string OriginalFileName { get; set; }
        public bool UseCustomSmtpServer { get; set; }
        public string SmtpServerUrl { get; set; }
        public string SmtpServerUserName { get; set; }
        public string SmtpServerPassword { get; set; }
        public string SmtpServerPort { get; set; }
        public string GoogleApiToken { get; set; }
    }

}
