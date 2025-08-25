using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Dtos.Responses
{
    public class CreatedNotificationResponse
    {
        public Guid Id { get; set; }
        public NotificationType notificationType { get; set; }
        public DayOfWeek? PreferredDayOfWeek { get; set; }
        public TimeOnly PreferredTime { get; set; }
        public bool NotificationIsActive { get; set; }
        public string Message { get; set; } = default!;
    }
}
