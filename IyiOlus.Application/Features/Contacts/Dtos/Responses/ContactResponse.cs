using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Dtos.Responses
{
    public class ContactResponse
    {
        public Guid ContactId { get; set; }
        public string Subject { get; set; } = default!;
        public string Message { get; set; } = default!;
        public bool isRead { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserResponse UserResponse { get; set; } = default!;
        public Guid UserResponseId { get; set; }

    }
}
