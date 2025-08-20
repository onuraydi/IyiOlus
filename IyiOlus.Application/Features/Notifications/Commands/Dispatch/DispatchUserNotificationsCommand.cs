using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Commands.Dispatch
{
    public class DispatchUserNotificationsCommand:IRequest<Unit>
    {
        public TimeOnly currentTime { get; set; }
        public class DispatchUserNotificationsCommandHandler : IRequestHandler<DispatchUserNotificationsCommand, Unit>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly INotificationSenderRepository _notificationSenderRepository;

            public DispatchUserNotificationsCommandHandler(INotificationRepository notificationRepository, INotificationSenderRepository notificationSenderRepository)
            {
                _notificationRepository = notificationRepository;
                _notificationSenderRepository = notificationSenderRepository;
            }

            public async Task<Unit> Handle(DispatchUserNotificationsCommand request, CancellationToken cancellationToken)
            {
                var notifications = await _notificationRepository.GetPreferredTimeAsync(request.currentTime, cancellationToken);

                foreach (var notification in notifications)
                {
                    var body = notification.notificationType switch
                    {
                        NotificationType.GünlükMod => $"{notification.User.Name}, bugün nasıl hissediyorsun?",
                        _ => "Yeni bildiriminiz var!",
                    };

                    var payload = new NotificationPayload
                    {
                        FcmToken = notification.User.FcmToken,
                        Title = "Hatırlatma",
                        Body = body,
                        Data = new Dictionary<string, string>
                        {
                            {
                                "type", notification.notificationType.ToString()
                            }
                        }
                    };

                    try
                    {
                        await _notificationSenderRepository.SendAsync(payload, cancellationToken);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }
                return Unit.Value;
            }
        }
    }
}
