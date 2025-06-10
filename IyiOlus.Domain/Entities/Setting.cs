using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Setting:Entity<Guid>
    {
        public TimeSpan NotificationTime { get; set; }
        public bool isActive { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
