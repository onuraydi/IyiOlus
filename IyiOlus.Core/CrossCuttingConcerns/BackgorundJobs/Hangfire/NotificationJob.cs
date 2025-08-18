using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.BackgorundJobs.Hangfire
{
    public class NotificationJob
    {
        public Task SendNotificationAsync(Guid userId,string message)
        {
            Console.WriteLine($"[Hangfire] Bildirim gönderiliyor: {userId} - {message}");
            return Task.CompletedTask;
        }
    }
}
