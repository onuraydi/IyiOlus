using IyiOlus.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class Daily:Entity<Guid>
    {
        public Guid DailyId { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime Date { get; set; }
        public Guid userId { get; set; }
        public User user { get; set; } = default!;
    }
}
