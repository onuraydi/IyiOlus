using Hangfire;
using IyiOlus.Application.Features.Notifications.Commands.Dispatch;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Hangfire
{
    public class NotificationScheduler
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationScheduler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchDueNotifications()
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await mediator.Send(new DispatchUserNotificationsCommand { currentTime = TimeOnly.FromDateTime(DateTime.Now) });
        }
    }

}
