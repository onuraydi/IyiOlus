using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Verification.Dtos.Requests
{
    public class CreateVerificationCodeRequest
    {
        public string code { get; set; } = default!;
    }
}
