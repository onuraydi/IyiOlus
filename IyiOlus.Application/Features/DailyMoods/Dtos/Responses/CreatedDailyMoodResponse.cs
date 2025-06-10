using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Dtos.Responses
{
    public class CreatedDailyMoodResponse
    {
        public Guid Id { get; set; }
        public Mood Mood { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; } = default!;
        public virtual UserResponse UserResponse { get; set; } = default!;
    }
}
