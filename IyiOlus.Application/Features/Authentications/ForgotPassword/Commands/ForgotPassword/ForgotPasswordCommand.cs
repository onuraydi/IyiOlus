using IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Responses;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Mail.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.ForgotPassword.Commands.ForgotPassword
{
    public class ForgotPasswordCommand:IRequest<ForgotPasswordResponse>
    {
        public ForgotPasswordRequest Request { get; set; } = default!;

        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMailSenderRepository _mailSenderRepository;
            private readonly IEmailVerificationRepository _emailVerificationRepository;

            public ForgotPasswordCommandHandler(UserManager<ApplicationUser> userManager, IMailSenderRepository mailSenderRepository, IEmailVerificationRepository emailVerificationRepository)
            {
                _userManager = userManager;
                _mailSenderRepository = mailSenderRepository;
                _emailVerificationRepository = emailVerificationRepository;
            }

            public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(command.Request.Email);
                if (user == null)
                    throw new Exception("Böyle bir kullanıcı yok");

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var code = new Random().Next(100000, 999999).ToString();

                await _emailVerificationRepository.AddAsync(new EmailVerification()
                {
                    UserId = user.Id,
                    Code = code,
                    Token = token,
                    ExpirationTime = DateTime.UtcNow.AddMinutes(5),
                });

                string body = "Şifre sıfırlamak için kod";
                string subject = "Şifre Sıfırlama";
                await _mailSenderRepository.SendMailAsync(user.Email, code, subject, body);

                return new ForgotPasswordResponse()
                {
                    Message = "Doğrulama maili gönderildi"
                };
            }
        }
    }
}
