using IyiOlus.Application.Features.Settings.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Rules
{
    public class SettingBusinessRules
    {
        private readonly ISettingRepository _settingRepository;

        public SettingBusinessRules(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task SettingNotFound(Guid settingId)
        {
            var result = await _settingRepository.AnyAsync(s => s.Id == settingId);
            if (!result)
                throw new Exception(SettingMessages.SettingNotFound);
        }
    }
}
