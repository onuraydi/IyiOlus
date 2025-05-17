using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Dtos.Responses
{
    public class DeletedUserAccountResponse
    {
        public Guid UserAccountInfoId { get; set; }
        public string Message { get; set; } = default!;
    }
}
