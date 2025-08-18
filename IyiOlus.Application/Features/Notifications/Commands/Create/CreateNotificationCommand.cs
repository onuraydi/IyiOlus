using AutoMapper;
using IyiOlus.Application.Features.Notifications.Constants;
using IyiOlus.Application.Features.Notifications.Dtos.Requests;
using IyiOlus.Application.Features.Notifications.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Commands.Create
{
    public class CreateNotificationCommand:IRequest<CreatedNotificationResponse>
    {
        public CreateNotificationRequest Request { get; set; } = default!;

        public class CreateNotificationCommandHandlder : IRequestHandler<CreateNotificationCommand, CreatedNotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public CreateNotificationCommandHandlder(INotificationRepository notificationRepository, IMapper mapper, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<CreatedNotificationResponse> Handle(CreateNotificationCommand command, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var notification = _mapper.Map<Notification>(command.Request);
                notification.UserId = userId;

                var createdNotification = await _notificationRepository.AddAsync(notification);

                var response = _mapper.Map<CreatedNotificationResponse>(createdNotification);
                response.Message = NotificationMessages.NotificationCreated;
                return response;
            }
        }
    }
}
