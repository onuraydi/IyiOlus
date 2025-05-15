using AutoMapper;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Features.Settings.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Queries.GetById
{
    public class GetByIdSettingQuery:IRequest<SettingResponse>
    {
        public Guid SettingId { get; set; }

        public class GetByIdSettingQueryHandler : IRequestHandler<GetByIdSettingQuery, SettingResponse>
        {
            private readonly ISettingRepository _settingRepository;
            private readonly IMapper _mapper;
            private readonly SettingBusinessRules _settingBusinessRules;

            public GetByIdSettingQueryHandler(ISettingRepository settingRepository, IMapper mapper, SettingBusinessRules settingBusinessRules)
            {
                _settingRepository = settingRepository;
                _mapper = mapper;
                _settingBusinessRules = settingBusinessRules;
            }

            public async Task<SettingResponse> Handle(GetByIdSettingQuery request, CancellationToken cancellationToken)
            {
                await _settingBusinessRules.SettingNotFound(request.SettingId);

                var setting = await _settingRepository.GetAsync(s => s.SettingId == request.SettingId);

                var response = _mapper.Map<SettingResponse>(setting);
                return response;
            }
        }
    }
}
