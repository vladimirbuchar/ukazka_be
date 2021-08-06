using Core.DataTypes;
using System;
using System.Collections.Generic;

namespace EduServices.SendMailService
{
    public interface ISendMailService : IBaseService
    {
        void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo, Guid organizationId, string reply);
        void SendMail(string emailIdentificator, string culture, EmailAddress emailAddressTo, Dictionary<string, string> replaceData, Guid organizationId, string reply);
        void SendEmail(string subject, string html, List<string> attachment, EmailAddress emailAddressTo, Guid organizationId, string reply);
    }
}
