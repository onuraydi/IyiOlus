using AutoMapper;
using IyiOlus.Application.Features.Settings.Constants;
using IyiOlus.Application.Features.Settings.Dtos.Requests;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Commands.Create
{
    public class CreateSettingCommand:IRequest<CreatedSettingResponse>
    {
        public CreateSettingRequest Request { get; set; } = default!;

        public class CreateSettingCommandRequest : IRequestHandler<CreateSettingCommand, CreatedSettingResponse>
        {
            private readonly ISettingRepository _settingRepository;
            private readonly IMapper _mapper;

            public CreateSettingCommandRequest(ISettingRepository settingRepository, IMapper mapper)
            {
                _settingRepository = settingRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSettingResponse> Handle(CreateSettingCommand command, CancellationToken cancellationToken)
            {
                var setting = _mapper.Map<Setting>(command.Request);

                var createdSetting = await _settingRepository.AddAsync(setting);

                var response = _mapper.Map<CreatedSettingResponse>(createdSetting);

                response.Message = SettingMessages.SettingCreated;

                return response;
            }
        }
    }
}
