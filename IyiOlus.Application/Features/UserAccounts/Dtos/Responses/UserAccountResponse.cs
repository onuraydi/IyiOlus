using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Dtos.Responses
{
    public class UserAccountResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool Status { get; set; }
        public bool isVerification { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserResponse? UserResponse { get; set; } = default!;
    }
}
