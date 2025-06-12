using AutoMapper;
using IyiOlus.Application.Features.Authentications.Constants;
using IyiOlus.Application.Features.Authentications.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.Dtos.Responses;
using IyiOlus.Application.Features.Authentications.Rules;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommand:IRequest<RegisterResponse>
    {
        public RegisterRequest Request { get; set; } = default!;

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
        {
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<Role> _roleManager;
            public RegisterCommandHandler(IMapper mapper, AuthBusinessRules authBusinessRules, UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
            {
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<RegisterResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
            {
                var email = await _userManager.FindByEmailAsync(command.Request.Email);
                if(email!= null)
                    await _authBusinessRules.UserShouldNotBeExist(email);

                var user = _mapper.Map<ApplicationUser>(command.Request);
                user.UserName = command.Request.Email;

                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, command.Request.Password);

                if(result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("user"))
                        await _roleManager.CreateAsync(new Role
                        {
                            Id = Guid.NewGuid(),
                            Name = "user",
                            NormalizedName = "USER",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });

                    await _userManager.AddToRoleAsync(user, "user");
                }

                var response = _mapper.Map<RegisterResponse>(user);
                response.Message = AuthenticationMessages.RegisterSucceeded;
                return response;
            }
        }
    }
}
