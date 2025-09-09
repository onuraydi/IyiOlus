using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Dtos.Requests
{
    public class CreateNotificationRequest
    {
        public NotificationType notificationType { get; set; }
        public DayOfWeek? PreferredDayOfWeek { get; set; }
        public bool NotificationIsActive { get; set; } = true;
        public TimeOnly PreferredTime { get; set; }
    }
}
