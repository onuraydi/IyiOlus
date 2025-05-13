using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Queries.GetList
{
    public class GetListProfileTypeQuery:IRequest<ProfileTypeResponse>
    {
        public class GetListProfileTypeQueryHandler : IRequestHandler<GetListProfileTypeQuery, ProfileTypeResponse>
        {
            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;

            public GetListProfileTypeQueryHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
            }

            public async Task<ProfileTypeResponse> Handle(GetListProfileTypeQuery request, CancellationToken cancellationToken)
            {
                var profileTypes = await _profileTypeRepository.GetListAsync(cancellationToken:cancellationToken);
                var response = _mapper.Map<ProfileTypeResponse>(profileTypes);
                return response;
            }
        }
    }
}
