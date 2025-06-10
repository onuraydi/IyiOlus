using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Dtos.Responses
{
    public class DeletedUserResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = default!;
    }
}
