using AutoMapper;
using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Requests;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand:IRequest<UpdatedUserResponse>
    {
        public UpdateUserRequest Request { get; set; } = default!;

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly UserManager<ApplicationUser> _userManager;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _userManager = userManager;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<UpdatedUserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserNotFound(command.Request.Id);
                _userBusinessRules.NameShort(command.Request.Name);
                _userBusinessRules.NameLong(command.Request.Name);
                _userBusinessRules.SurnameShort(command.Request.Surname);
                _userBusinessRules.SurnameLong(command.Request.Surname);

                var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var appUser = await _userManager.FindByEmailAsync(email);
                var userId = appUser.Id;

                var user = await _userRepository.GetAsync(u => u.Id == command.Request.Id);
                _mapper.Map(command.Request, user);

                user.ApplicationUserId = userId;

                var updatedUser = await _userRepository.UpdateAsync(user);

                var response = _mapper.Map<UpdatedUserResponse>(updatedUser);
                response.Message = UserMessages.UserUpdated;

                return response;
            }
        }
    }
}
