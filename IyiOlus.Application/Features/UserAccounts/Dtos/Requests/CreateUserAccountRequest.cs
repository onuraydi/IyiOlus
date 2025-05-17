using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Dtos.Requests
{
    public class CreateUserAccountRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool Status { get; set; }
        public bool isVerification { get; set; }
    }
}
