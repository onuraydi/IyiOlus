using IyiOlus.Domain.Entities;
using PT = IyiOlus.Domain.Enums.ProfileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Dtos.Requests
{
    public class CreateProfileTypeRequest
    {
        public PT Type { get; set; }
        //public virtual ICollection<Question> Questions { get; set; } = default!;
        //public virtual ICollection<UserProfile> UserProfiles { get; set; } = default!;
    }
}
