using AutoMapper;
using IyiOlus.Application.Features.Authentications.Login.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.Login.Dtos.Responses;
using IyiOlus.Application.Features.Authentications.Login.Rules;
using IyiOlus.Core.Repositories.Token;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Login.Commands.Login
{
    public class LoginCommand:IRequest<LoginResponse>
    {
        public LoginRequest Request { get; set; } = default!;

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;
            private readonly LoginBusinessRules _loginBusinessRules;
            private readonly ITokenService _tokenService;
            private readonly IConfiguration _configuration;
            public LoginCommandHandler(UserManager<ApplicationUser> user, IMapper mapper, LoginBusinessRules loginBusinessRules, RoleManager<Role> roleManager, ITokenService tokenService, IConfiguration configuration)
            {
                _userManager = user;
                _mapper = mapper;
                _loginBusinessRules = loginBusinessRules;
                _roleManager = roleManager;
                _tokenService = tokenService;
                _configuration = configuration;
            }

            public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(command.Request.Email);

                bool checkPassword = await _userManager.CheckPasswordAsync(user, command.Request.Password);

                await _loginBusinessRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

                IList<string> roles = await _userManager.GetRolesAsync(user);

                JwtSecurityToken token = await _tokenService.CreateTokenAsync(user, roles);
                string refreshToken = _tokenService.GenerateRefreshToken();
                var days = _configuration["JWT:RefreshTokenValidityInDays"];
                int.TryParse(days, out int refreshTokenValidityInDays);

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                await _userManager.UpdateAsync(user);
                await _userManager.UpdateSecurityStampAsync(user);
                var _token = new JwtSecurityTokenHandler().WriteToken(token);

                await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

                return new()
                {
                    Token = _token,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    Message = "Giriş Başarılı"
                };
            }
        }
    }
}
