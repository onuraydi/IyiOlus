using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Dtos.Requests
{
    public class CreateContactRequest
    {
        public string Subject { get; set; } = default!;
        public string Message { get; set; } = default!;
        //public Guid UserId { get; set; }
    }
}
