using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.ForgotPassword.Dtos.Requests
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = default!;
    }
}
