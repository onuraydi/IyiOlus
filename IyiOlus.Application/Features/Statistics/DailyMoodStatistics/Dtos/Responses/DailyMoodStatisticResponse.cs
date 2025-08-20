using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Dtos.Responses
{
    public class DailyMoodStatisticResponse
    {
        public Mood Mood { get; set; }
        public DateTime Date { get; set; }
    }
}
