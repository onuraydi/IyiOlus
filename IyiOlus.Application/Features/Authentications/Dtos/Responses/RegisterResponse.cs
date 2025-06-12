using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Dtos.Responses
{
    public class RegisterResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string Message { get; set; } = default!;
    }
}
