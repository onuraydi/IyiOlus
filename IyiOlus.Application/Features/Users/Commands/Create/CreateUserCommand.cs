using AutoMapper;
using IyiOlus.Application.Features.Notifications.Dtos.Requests;
using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Requests;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Commands.Create
{
    public class CreateUserCommand:IRequest<CreatedUserResponse>
    {
        public CreateUserRequest Request { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly INotificationRepository _notificationRepository;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, INotificationRepository notificationRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _httpContextAccessor = httpContextAccessor;
                _userManager = userManager;
                _notificationRepository = notificationRepository;
            }

            public async Task<CreatedUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                _userBusinessRules.NameShort(command.Request.Name);
                _userBusinessRules.NameLong(command.Request.Name);

                _userBusinessRules.SurnameShort(command.Request.Surname);
                _userBusinessRules.SurnameLong(command.Request.Surname);

                

                var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var appUser = await _userManager.FindByEmailAsync(email);
                var userId = appUser.Id;

                var user = _mapper.Map<User>(command.Request);
                user.ApplicationUserId = userId;

                user.Notifications ??= new List<Notification>();

                user.Notifications.Add(new Notification
                {
                    notificationType = NotificationType.GünlükMod,
                    NotificationIsActive = true,
                    PreferedTime = new TimeOnly(9, 0)
                });

                user.Notifications.Add(new Notification
                {
                    notificationType = NotificationType.Profilleme,
                    NotificationIsActive = true,
                    PrefferedDayOfWeek = DayOfWeek.Sunday,
                    PreferedTime = new TimeOnly(20, 0)
                });



                var createdUser = await _userRepository.AddAsync(user);

                var response = _mapper.Map<CreatedUserResponse>(createdUser);
                response.Message = UserMessages.UserCreated;

                return response;
            }
        }
    }
}
