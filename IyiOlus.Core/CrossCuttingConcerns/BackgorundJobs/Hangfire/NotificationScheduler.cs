using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.BackgorundJobs.Hangfire
{
    public class NotificationScheduler
    {
        private readonly NotificationJob _notificationJob;

        public NotificationScheduler(NotificationJob notificationJob)
        {
            _notificationJob = notificationJob;
        }

        [Obsolete]
        public void ScheduleDailyNotification(Guid userId,string userName, TimeOnly time)
        {
            var cronExpression = Cron.Daily(time.Hour, time.Minute);

            RecurringJob.AddOrUpdate(
                $"daily-notification-{userId}",
                () => _notificationJob.SendNotificationAsync(userId, $"{userName}, Bugün nasıl hissediyorsun"),
                cronExpression,
                TimeZoneInfo.Local
            );
        }
    }
}
