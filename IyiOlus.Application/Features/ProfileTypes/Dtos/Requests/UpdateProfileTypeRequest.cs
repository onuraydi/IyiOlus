using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT = IyiOlus.Domain.Enums.ProfileTypes;

namespace IyiOlus.Application.Features.ProfileTypes.Dtos.Requests
{
    public class UpdateProfileTypeRequest
    {
        public Guid Id { get; set; }
        public PT Type { get; set; }
    }
}
