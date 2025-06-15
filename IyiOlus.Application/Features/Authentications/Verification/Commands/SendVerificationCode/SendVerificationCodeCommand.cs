using IyiOlus.Application.Features.Authentications.Verification.Dtos.Responses;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Mail.Repositories;
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

namespace IyiOlus.Application.Features.Authentications.Verification.Commands.SendVerificationCode
{
    public class SendVerificationCodeCommand:IRequest<VerificationCodeResponse>
    {
        public class SendVerificationCodeCommandHandler : IRequestHandler<SendVerificationCodeCommand, VerificationCodeResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMailSenderRepository _mailSenderRepository;
            private readonly IEmailVerificationRepository _emailVerificationRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public SendVerificationCodeCommandHandler(UserManager<ApplicationUser> userManager, IMailSenderRepository mailSenderRepository, IEmailVerificationRepository emailVerificationRepository, IHttpContextAccessor httpContextAccessor)
            {
                _userManager = userManager;
                _mailSenderRepository = mailSenderRepository;
                _emailVerificationRepository = emailVerificationRepository;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<VerificationCodeResponse> Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
            {
                var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
                var appUser = await _userManager.FindByEmailAsync(email);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                var code = new Random().Next(100000, 999999).ToString();

                var sendedCode = await _emailVerificationRepository.AddAsync(new EmailVerification
                {
                    UserId = appUser.Id,
                    Code = code,
                    Token = token,
                    ExpirationTime = DateTime.Now.AddMinutes(5)
                });

                string body = "mail adresinizi doğrulama için kod";
                string subject = "Hesap Doğrulama";
                await _mailSenderRepository.SendMailAsync(email, code, subject, body);

                return new VerificationCodeResponse()
                {
                    Email = email,
                    message = "Doğrulama maili gönderildi."
                };
            }
        }
    }
}
