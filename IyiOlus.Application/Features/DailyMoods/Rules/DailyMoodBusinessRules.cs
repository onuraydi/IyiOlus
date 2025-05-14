using IyiOlus.Application.Features.DailyMoods.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Rules
{
    public class DailyMoodBusinessRules
    {
        private readonly IDailyMoodRepository _dailyMoodRepository;

        public DailyMoodBusinessRules(IDailyMoodRepository dailyMoodRepository)
        {
            _dailyMoodRepository = dailyMoodRepository;
        }

        public async Task DailyMoodNotFound(Guid dailyMoodId)
        {
            var result = await _dailyMoodRepository.AnyAsync(dm => dm.DailyMoodId == dailyMoodId);
            if (!result)
                throw new Exception(DailyMoodMessages.DailyMoodNotFound);
        }
    }
}
