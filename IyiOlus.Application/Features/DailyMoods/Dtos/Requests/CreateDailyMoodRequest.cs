using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Dtos.Requests
{
    public class CreateDailyMoodRequest
    {
        public Mood Mood { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
