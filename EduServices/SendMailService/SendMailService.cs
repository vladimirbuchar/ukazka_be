using Core.DataTypes;
using EduRepository.EmailRepository;
using EduRepository.OrganizationRepository;
using Integration.MailKitIntegration;
using Model.Functions;
using Model.Functions.UserInOrganization;
using System;
using System.Collections.Generic;

namespace EduServices.SendMailService
{
    public class SendMailService : BaseService, ISendMailService
    {
        private readonly IMailKitIntegration _sendGridIntegration;
        private readonly IEmailRepository _emailRepository;
        private readonly IOrganizationRepository _organizationRepository;


        public SendMailService(IMailKitIntegration sendGridIntegration, IEmailRepository emailRepository, IOrganizationRepository organizationRepository)
        {
            _sendGridIntegration = sendGridIntegration;
            _emailRepository = emailRepository;
            _organizationRepository = organizationRepository;
        }

        public void SendEmail(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply)
        {
            GetOrganizationSetting getOrganizationSetting = _organizationRepository.GetOrganizationSetting(organizationId);
            if (getOrganizationSetting != null && getOrganizationSetting.UseCustomSmtpServer)
            {
                _sendGridIntegration.SendEmail(new Email()
                {
                    EmailBody = new EmailBody()
                    {
                        HtmlBody = html,
                        IsHtml = true,
                        PlainTextBody = html
                    },
                    To = emailAddressTo,
                    Subject = subject,
                    Attachment = attachment,
                    From = new EmailAddress()
                    {
                        Email = reply
                    }
                },
                getOrganizationSetting.SmtpServerUrl,
                Convert.ToInt32(getOrganizationSetting.SmtpServerPort),
                getOrganizationSetting.SmtpServerUserName,
                getOrganizationSetting.SmtpServerPassword, ""


                );
            }
            else
            {
                _sendGridIntegration.SendEmail(new Email()
                {
                    EmailBody = new EmailBody()
                    {
                        HtmlBody = html,
                        IsHtml = true,
                        PlainTextBody = html
                    },
                    To = emailAddressTo,
                    Subject = subject,
                    Attachment = attachment
                }, reply);
            }

        }

        public void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo, Dictionary<string, string> replaceData, Guid organizationId, string reply)
        {
            GetEmail eduEmail = _emailRepository.GetEmail(string.Format("{0}_{1}", emailIdentificator, culture));

            if (eduEmail == null)
            {
                culture = "en";
                _emailRepository.GetEmail(string.Format("{0}_{1}", emailIdentificator, culture));
            }
            if (eduEmail != null)
            {
                foreach (KeyValuePair<string, string> item in replaceData)
                {
                    eduEmail.EmailBodyHtml = eduEmail.EmailBodyHtml.Replace("{" + item.Key + "}", item.Value);
                    eduEmail.EmailBodyPlainText = eduEmail.EmailBodyPlainText.Replace("{" + item.Key + "}", item.Value);
                }
                GetOrganizationSetting getOrganizationSetting = _organizationRepository.GetOrganizationSetting(organizationId);
                if (getOrganizationSetting != null && getOrganizationSetting.UseCustomSmtpServer)
                {
                    _sendGridIntegration.SendEmail(new Email()
                    {
                        EmailBody = new EmailBody()
                        {
                            HtmlBody = eduEmail.EmailBodyHtml,
                            IsHtml = eduEmail.IsHtml,
                            PlainTextBody = eduEmail.EmailBodyPlainText
                        },
                        To = emailAddressTo,
                        Subject = eduEmail.Subject,
                        From = new EmailAddress()
                        {
                            Email = reply
                        }
                    },
                    getOrganizationSetting.SmtpServerUrl,
                    Convert.ToInt32(getOrganizationSetting.SmtpServerPort),
                    getOrganizationSetting.SmtpServerUserName,
                    getOrganizationSetting.SmtpServerPassword,
                    ""


                    );
                }
                else
                {
                    _sendGridIntegration.SendEmail(new Email()
                    {
                        EmailBody = new EmailBody()
                        {
                            HtmlBody = eduEmail.EmailBodyHtml,
                            IsHtml = eduEmail.IsHtml,
                            PlainTextBody = eduEmail.EmailBodyPlainText
                        },
                        To = emailAddressTo,
                        From = new EmailAddress()
                        {
                            Email = eduEmail.From,
                            Name = eduEmail.From
                        },
                        Subject = eduEmail.Subject
                    }, reply);
                }
            }
        }

        public void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo, Guid organizationId, string reply)
        {
            SendMail(emailIdentificator, culture, emailAddressTo, new Dictionary<string, string>(), organizationId, reply);
        }
    }
}
