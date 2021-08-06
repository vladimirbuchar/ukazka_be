using System;
using System.Collections.Generic;
using WebModel.Notification;

namespace EduFacade.NotificationFacade
{
    public interface INotificationFacade : IBaseFacade
    {
        HashSet<GetMyNotificationDto> GetMyNotification(Guid userId, bool onlyNew);
        void SetIsNewNotificationToFalse(Guid userId);
    }
}
