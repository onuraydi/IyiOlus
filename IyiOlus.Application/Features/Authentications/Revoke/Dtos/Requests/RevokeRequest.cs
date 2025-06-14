using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Revoke.Dtos.Requests
{
    public class RevokeRequest
    {
        public string Email { get; set; } = default!;
    }
}
