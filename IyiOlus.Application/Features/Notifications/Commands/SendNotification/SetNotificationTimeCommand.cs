using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.CrossCuttingConcerns.BackgorundJobs.Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Commands.SendNotification
{
    public class SetNotificationTimeCommand:IRequest
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = default!;
        public TimeOnly PreferedTime { get; set; }

        //public class SetNotificationTimeCommandHandler : IRequestHandler<SetNotificationTimeCommand>
        //{
        //    private readonly INotificationRepository _notificationRepository;
        //    private readonly NotificationScheduler _notificationScheduler;

        //    public SetNotificationTimeCommandHandler(INotificationRepository notificationRepository, NotificationScheduler notificationScheduler)
        //    {
        //        _notificationRepository = notificationRepository;
        //        _notificationScheduler = notificationScheduler;
        //    }

        //    public async Task Handle(SetNotificationTimeCommand request, CancellationToken cancellationToken)
        //    {
        //        var notification = await _notificationRepository.GetAsync(
        //            predicate: x => x.UserId == request.UserId && x.PreferedTime == request.PreferedTime,
        //            cancellationToken: cancellationToken
        //        );

        //        if(notification == null)
        //        {
        //            // burda deault bir ekleme yap 
        //        }

        //        _notificationScheduler.ScheduleDailyNotification(request.UserId, request.UserName, request.PreferedTime);

        //        return Unit.Value;
        //    }
        //}
    }
}
