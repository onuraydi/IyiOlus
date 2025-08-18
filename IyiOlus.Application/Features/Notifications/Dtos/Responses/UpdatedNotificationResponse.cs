using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Dtos.Responses
{
    public class UpdatedNotificationResponse
    {
        public Guid Id { get; set; }
        public NotificationType notificationType { get; set; }
        public TimeOnly PreferedTime { get; set; }
        public string Message { get; set; } = default!;
    }
}
