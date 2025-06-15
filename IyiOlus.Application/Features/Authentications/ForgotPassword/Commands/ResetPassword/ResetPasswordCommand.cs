using IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Responses;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.ForgotPassword.Commands.ResetPassword
{
    public class ResetPasswordCommand:IRequest<ForgotPasswordResponse>
    {
        public ResetPasswordRequest Request { get; set; } = default!;

        public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ForgotPasswordResponse>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IEmailVerificationRepository _emailVerificationRepository;

            public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IEmailVerificationRepository emailVerificationRepository)
            {
                _userManager = userManager;
                _emailVerificationRepository = emailVerificationRepository;
            }

            public async Task<ForgotPasswordResponse> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(command.Request.Email);

                var code = await _emailVerificationRepository.GetAsync(
                    predicate: x => x.Code == command.Request.Code && x.ExpirationTime > DateTime.UtcNow 
                            && !x.IsUsed && x.UserId == user.Id);

                
                var result = await _userManager.ResetPasswordAsync(user, code.Token, command.Request.NewPassword);

                if (!result.Succeeded)
                    throw new Exception("Şifre değiştirme işlemi başarısız oldu!");

                code.IsUsed = true;

                return new ForgotPasswordResponse()
                {
                    Message = "Şifre değişikliği başarıyla gerçekleştirildi."
                };
            }
        }
    }
}
