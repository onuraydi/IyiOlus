using AutoMapper;
using IyiOlus.Application.Features.Authentications.Revoke.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.Revoke.Dtos.Responses;
using IyiOlus.Application.Features.Authentications.Revoke.Rules;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Revoke.Commands.Revoke
{
    public class RevokeCommand:IRequest<RevokeResponse>
    {
        public RevokeRequest Request { get; set; } = default!;

        public class RevokeCommandHanlder : IRequestHandler<RevokeCommand, RevokeResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RevokeBusinessRules _revokeBusinessRules;

            public RevokeCommandHanlder(UserManager<ApplicationUser> userManager, RevokeBusinessRules revokeBusinessRules)
            {
                _userManager = userManager;
                _revokeBusinessRules = revokeBusinessRules;
            }

            public async Task<RevokeResponse> Handle(RevokeCommand command, CancellationToken cancellationToken)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(command.Request.Email);
                await _revokeBusinessRules.EmailAddressShouldBeValid(user);

                user.RefreshToken = null;

                await _userManager.UpdateAsync(user);
                return new()
                {
                    Message = "Çıkış başarılı"
                };
            }
        }
    }
}
