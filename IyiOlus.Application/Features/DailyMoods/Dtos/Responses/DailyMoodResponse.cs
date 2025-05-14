using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Dtos.Responses
{
    public class DailyMoodResponse
    {
        public Guid DailyMoodId { get; set; }
        public Mood Mood { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } 
        //public Guid UserId { get; set; }
        //public User User { get; set; } = default!;
    }
}
