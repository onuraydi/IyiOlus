using AutoMapper;
using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IyiOlus.Application.Features.Users.Commands.UpdateUserToken
{
    public class UpdateFcmTokenCommand:IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public string newToken { get; set; } = default!;

        public class UpdateFcmTokenCommandHandler : IRequestHandler<UpdateFcmTokenCommand, UserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateFcmTokenCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserResponse> Handle(UpdateFcmTokenCommand command, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserNotFound(command.Id);

                var user = await _userRepository.GetAsync(u => u.Id == command.Id);
                user.FcmToken = command.newToken;
                var updatedUser = await _userRepository.UpdateAsync(user);

                var response = _mapper.Map<UserResponse>(updatedUser);

                return response;
            }
        }
    }
}
