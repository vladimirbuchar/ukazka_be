using Model.Functions.Notification;
using System.Collections.Generic;
using WebModel.Notification;

namespace EduFacade.NotificationFacade.Convertor
{
    public interface INotificationConvertor
    {
        HashSet<GetMyNotificationDto> ConvertToWebModel(HashSet<GetMyNotification> getMyNotifications);
    }
}
