using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Dtos.Responses
{
    public class NotificationResponse
    {
        public Guid Id { get; set; }
        public NotificationType notificationType { get; set; }
        public DayOfWeek? PrefferedDayOfWeek { get; set; }
        public bool NotificationIsActive { get; set; }
        public TimeOnly PreferedTime { get; set; }
    }
}
