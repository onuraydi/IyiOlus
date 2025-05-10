using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class DailyMood:Entity<Guid>
    {
        public Guid DailyMoodId { get; set; }
        public Mood Mood { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
