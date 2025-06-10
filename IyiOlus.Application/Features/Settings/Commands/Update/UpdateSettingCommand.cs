using AutoMapper;
using IyiOlus.Application.Features.Settings.Constants;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Features.Settings.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Commands.Update
{
    public class UpdateSettingCommand:IRequest<UpdatedSettingResponse>
    {
        public Guid SettingId { get; set; }

        public class UpdateSettingCommandHanlder : IRequestHandler<UpdateSettingCommand, UpdatedSettingResponse>
        {
            private readonly ISettingRepository _settingRepository;
            private readonly IMapper _mapper;
            private readonly SettingBusinessRules _settingBusinessRules;

            public UpdateSettingCommandHanlder(ISettingRepository settingRepository, IMapper mapper, SettingBusinessRules settingBusinessRules)
            {
                _settingRepository = settingRepository;
                _mapper = mapper;
                _settingBusinessRules = settingBusinessRules;
            }

            public async Task<UpdatedSettingResponse> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
            {
                await _settingBusinessRules.SettingNotFound(request.SettingId);

                var setting = await _settingRepository.GetAsync(s => s.Id == request.SettingId);

                var updatedSetting = await _settingRepository.UpdateAsync(setting);

                var response = _mapper.Map<UpdatedSettingResponse>(updatedSetting);

                response.Messages = SettingMessages.SettingUpdated;

                return response;
            }
        }
    }
}
