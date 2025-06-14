using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT = IyiOlus.Domain.Enums.ProfileTypes;

namespace IyiOlus.Application.Features.ProfileTypes.Dtos.Responses
{
    public class CreatedProfileTypeResponse
    {
        public Guid Id { get; set; }
        public PT Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
