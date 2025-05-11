using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT = IyiOlus.Domain.Enums.ProfileTypes;

namespace IyiOlus.Application.Features.ProfileTypes.Dtos.Responses
{
    public class UpdatedProfileTypeResponse
    {
        public Guid ProfileTypeId { get; set; }
        public PT ProfileType { get; set; }
        //public virtual ICollection<Question> Questions { get; set; } = default!;
        //public virtual ICollection<UserProfile> UserProfiles { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
