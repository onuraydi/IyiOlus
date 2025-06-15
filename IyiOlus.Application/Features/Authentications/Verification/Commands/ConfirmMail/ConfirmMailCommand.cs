using IyiOlus.Application.Features.Authentications.Verification.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.Verification.Dtos.Responses;
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

namespace IyiOlus.Application.Features.Authentications.Verification.Commands.ConfirmMail
{
    public class ConfirmMailCommand:IRequest<VerificationCodeResponse>
    {
        public string code { get; set; } = default!;
        public class ConfirmMailCommandHanlder : IRequestHandler<ConfirmMailCommand, VerificationCodeResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IEmailVerificationRepository _emailVerificationRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            public ConfirmMailCommandHanlder(UserManager<ApplicationUser> userManager, IEmailVerificationRepository emailVerificationRepository, IHttpContextAccessor httpContextAccessor)
            {
                _userManager = userManager;
                _emailVerificationRepository = emailVerificationRepository;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<VerificationCodeResponse> Handle(ConfirmMailCommand request, CancellationToken cancellationToken)
            {
                var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var appUser = await _userManager.FindByEmailAsync(email);

                var code = await _emailVerificationRepository.GetAsync(
                    predicate: x => x.Code == request.code && 
                                x.ExpirationTime > DateTime.UtcNow && !x.IsUsed
                                && x.UserId == appUser.Id);

                var result = await _userManager.ConfirmEmailAsync(appUser, code.Token);
                if (!result.Succeeded)
                    throw new Exception("Kod Doğrulanamadı");

                code.IsUsed = true;
                return new VerificationCodeResponse()
                {
                    Email = email,
                    message = "mail adresiniz başarıyla doğrulandı",
                };
            }
        }
    }
}
