using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Contact:Entity<Guid>
    {
        public Guid ContactId { get; set; }
        public string Subject { get; set; } = default!;
        public string Message { get; set; } = default!;
        public bool isRead { get; set; }
        public virtual ICollection<User> Users { get; set; } = default!;
    }
}
