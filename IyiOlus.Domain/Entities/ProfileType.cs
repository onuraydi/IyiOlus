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
        public Guid ProfileTypeId { get; set; }
        public ProfileTypes Type { get; set; }
    }
}
