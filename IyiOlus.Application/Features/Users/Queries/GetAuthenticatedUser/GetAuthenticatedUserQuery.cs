using AutoMapper;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.CrossCuttingConcerns.BackgorundJobs.Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQuery:IRequest<UserResponse>
    {
        public class GetAuthenticatedUserQueryHandler : IRequestHandler<GetAuthenticatedUserQuery, UserResponse>
        {
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly NotificationScheduler _notificationScheduler;
            private readonly INotificationRepository _notificationRepository;

            public GetAuthenticatedUserQueryHandler(IAuthenticatedUserRepository authenticatedUserRepository, IMapper mapper, IUserRepository userRepository, NotificationScheduler notificationScheduler, INotificationRepository notificationRepository)
            {
                _authenticatedUserRepository = authenticatedUserRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _notificationScheduler = notificationScheduler;
                _notificationRepository = notificationRepository;
            }

            [Obsolete]
            public async Task<UserResponse> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var user = await _userRepository.GetAsync(
                    predicate: x => x.Id == userId,
                    cancellationToken: cancellationToken
                );

                var notification = await _notificationRepository.GetAsync(predicate: x => x.UserId == userId);

                _notificationScheduler.ScheduleDailyNotification(userId, user.Name, notification.PreferedTime);

                var response = _mapper.Map<UserResponse>(user);
                return response;
            }
        }
    }
}
