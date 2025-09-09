using AutoMapper;
using IyiOlus.Application.Features.Notifications.Constants;
using IyiOlus.Application.Features.Notifications.Dtos.Requests;
using IyiOlus.Application.Features.Notifications.Dtos.Responses;
using IyiOlus.Application.Features.Notifications.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Commands.Update
{
    public class UpdateNotificationCommand:IRequest<UpdatedNotificationResponse>
    {
        public UpdateNotificationRequest Request { get; set; } = default!;

        public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdatedNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            private readonly NotificationBusinessRules _notificationBusinessRules;

            public UpdateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper, NotificationBusinessRules notificationBusinessRules)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _notificationBusinessRules = notificationBusinessRules;
            }

            public async Task<UpdatedNotificationResponse> Handle(UpdateNotificationCommand command, CancellationToken cancellationToken)
            {
                await _notificationBusinessRules.NotificationNotFound(command.Request.Id);

                var notification = await _notificationRepository.GetAsync(x => x.Id == command.Request.Id);
                _mapper.Map(command.Request, notification);

                var updatedExercise = await _notificationRepository.UpdateAsync(notification);

                var response = _mapper.Map<UpdatedNotificationResponse>(updatedExercise);
                response.Message = NotificationMessages.NotificationUpdated;
                return response;
            }
        }
    }
}
