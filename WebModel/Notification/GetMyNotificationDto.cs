using System;
using System.Collections.Generic;

namespace WebModel.Notification
{
    public class GetMyNotificationDto
    {
        public Guid Id { get; set; }
        public string NotificationIdentificator { get; set; }
        public Guid ObjectId { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public bool IsNew { get; set; }
        public DateTime AddDate { get; set; }
    }
}
