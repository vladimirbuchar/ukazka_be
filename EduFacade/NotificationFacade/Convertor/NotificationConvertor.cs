using Model.Functions.Notification;
using System.Collections.Generic;
using System.Linq;
using WebModel.Notification;

namespace EduFacade.NotificationFacade.Convertor
{
    public class NotificationConvertor : INotificationConvertor
    {
        public HashSet<GetMyNotificationDto> ConvertToWebModel(HashSet<GetMyNotification> getMyNotifications)
        {
            return getMyNotifications.Select(item => new GetMyNotificationDto()
            {
                Id = item.Id,
                NotificationIdentificator = item.NotificationIdentificator,
                ObjectId = item.ObjectId,
                Data = item.Data,
                AddDate = item.AddDate,
                IsNew = item.IsNew
            }).ToHashSet();
        }
    }
}
