using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Login.Dtos.Responses
{
    public class LoginResponse
    {
        public string Fullname { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string Token { get; set; } = default!;
        public string RefreshToken { get; set; } = default!;
        public DateTime Expiration { get; set; }
    }
}
