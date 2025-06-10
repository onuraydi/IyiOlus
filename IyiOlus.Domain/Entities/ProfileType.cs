using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class ProfileType:Entity<Guid>
    {
        public ProfileTypes Type { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = default!;
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = default!;
    }
}
