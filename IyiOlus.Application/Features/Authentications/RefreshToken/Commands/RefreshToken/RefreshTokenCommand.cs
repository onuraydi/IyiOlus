using AutoMapper;
using IyiOlus.Application.Features.Authentications.RefreshToken.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.RefreshToken.Dtos.Responses;
using IyiOlus.Application.Features.Authentications.RefreshToken.Rules;
using IyiOlus.Core.Repositories.Token;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.RefreshToken.Commands.RefreshToken
{
    public class RefreshTokenCommand:IRequest<RefreshTokenResponse>
    {
        public RefreshTokenRequest Request { get; set; } = default!;

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
        {
            private readonly IMapper _mapper;
            private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ITokenService _tokenService;
            private readonly RefreshTokenBusinessRules _refreshTokenBusinessRules1;

            public RefreshTokenCommandHandler(IMapper mapper, RefreshTokenBusinessRules refreshTokenBusinessRules, UserManager<ApplicationUser> userManager, ITokenService tokenService, RefreshTokenBusinessRules refreshTokenBusinessRules1)
            {
                _mapper = mapper;
                _refreshTokenBusinessRules = refreshTokenBusinessRules;
                _userManager = userManager;
                _tokenService = tokenService;
                _refreshTokenBusinessRules1 = refreshTokenBusinessRules1;
            }

            public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
            {
                var principal = _tokenService.GetPrincipalFromExpiredToken(command.Request.AccessToken);
                string email = principal.FindFirstValue(ClaimTypes.Email);

                var user = await _userManager.FindByEmailAsync(email);
                IList<string> roles = await _userManager.GetRolesAsync(user);

                await _refreshTokenBusinessRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

                JwtSecurityToken newAccessToken = await _tokenService.CreateTokenAsync(user, roles);

                string newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                await _userManager.UpdateAsync(user);

                return new()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                    RefreshToken = newRefreshToken
                };
            }
        }
    }
}
