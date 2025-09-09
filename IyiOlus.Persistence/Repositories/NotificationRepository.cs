using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using IyiOlus.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Persistence.Repositories
{
    public class NotificationRepository : EfRepositoryBase<Notification, Guid, BaseDbContext>,INotificationRepository
    {
        public NotificationRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetPreferredTimeAsync(TimeOnly time, DateTime dateTime, CancellationToken cancellationToken)
        {
            return await context.Notifications
                .Include(n => n.User)
                .Where(x => (x.notificationType == NotificationType.GünlükMod && x.PreferredTime.Hour == time.Hour && x.PreferredTime.Minute == time.Minute)
                ||
                (x.notificationType == NotificationType.Profilleme && x.PreferredDayOfWeek == dateTime.DayOfWeek && x.PreferredTime.Hour == time.Hour && x.PreferredTime.Minute == time.Minute)
                ).ToListAsync(cancellationToken);
        }
    }
}
