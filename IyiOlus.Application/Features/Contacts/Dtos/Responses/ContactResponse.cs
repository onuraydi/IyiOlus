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
        //public Guid UserId { get; set; }
        //public User User { get; set; } = default!;
        public DateTime CreatedDate { get; set; }

    }
}
