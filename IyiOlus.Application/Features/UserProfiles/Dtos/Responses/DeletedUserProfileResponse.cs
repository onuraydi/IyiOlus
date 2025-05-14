using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Dtos.Responses
{
    public class DeletedUserProfileResponse
    {
        public Guid UserProfileId { get; set; }
        public string Message { get; set; } = default!;
    }
}
