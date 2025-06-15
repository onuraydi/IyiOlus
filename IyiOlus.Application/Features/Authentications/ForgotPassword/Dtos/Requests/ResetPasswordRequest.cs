using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Requests
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmNewPassword { get; set; } = default!;
    }
}
