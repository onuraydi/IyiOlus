using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Notification:Entity<Guid>
    {
        public bool NotificationIsActive { get; set; }
        public NotificationType notificationType { get; set; }
        public TimeOnly PreferredTime { get; set; }
        public DayOfWeek? PreferredDayOfWeek { get; set; }
        public virtual User User { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}
