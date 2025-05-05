using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class UserRole:Entity<Guid>
    {
        public Guid UserRoleId { get; set; }
        public UserRoles Role { get; set; }

    }
}
