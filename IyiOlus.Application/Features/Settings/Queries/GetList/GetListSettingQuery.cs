using AutoMapper;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Queries.GetList
{
    public class GetListSettingQuery:IRequest<Paginate<SettingResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListSettingQueryHandler : IRequestHandler<GetListSettingQuery, Paginate<SettingResponse>>
        {
            private readonly ISettingRepository _settingRepository;
            private readonly IMapper _mapper;

            public GetListSettingQueryHandler(ISettingRepository settingRepository, IMapper mapper)
            {
                _settingRepository = settingRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<SettingResponse>> Handle(GetListSettingQuery request, CancellationToken cancellationToken)
            {
                var setting = await _settingRepository.GetListAsync(
                        index:request.PageIndex,
                        size:request.PageSize,
                        cancellationToken:cancellationToken
                    );

                var response = _mapper.Map<Paginate<SettingResponse>>(setting);
                return response;
            }
        }
    }
}
