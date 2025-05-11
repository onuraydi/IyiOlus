using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Dtos.Responses
{
    public class DeletedContactResponse
    {
        public Guid ContactId { get; set; }
        public string Message { get; set; } = default!;
    }
}
