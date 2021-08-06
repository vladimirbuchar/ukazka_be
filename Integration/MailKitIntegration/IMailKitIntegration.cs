using Core.DataTypes;

namespace Integration.MailKitIntegration
{
    public interface IMailKitIntegration
    {
        void SendEmail(Email mail, string reply);
        void SendEmail(Email mail, string smtpServer, int smtpPort, string smtpUser, string smtpPassword, string reply);
    }
}
