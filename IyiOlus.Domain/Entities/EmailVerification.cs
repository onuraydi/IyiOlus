using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class EmailVerification:Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Code { get; set; } = default!;
        public string Token { get; set; } = default!;
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; }
    }
}
