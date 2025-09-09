using IyiOlus.Application.Features.Notifications.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Rules
{
    public class NotificationBusinessRules
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationBusinessRules(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task NotificationNotFound(Guid id)
        {
            var notification = await _notificationRepository.AnyAsync(x => x.Id == id);
            if (!notification)
            {
                throw new Exception(NotificationMessages.NotificationNotFound);
            }
        }
    }
}
