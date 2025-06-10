using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class UserAccountInfo:Entity<Guid>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool Status { get; set; }
        public bool isVerification { get; set; }
        public virtual User? User { get; set; } = default!;
    }
}
