using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Queries.GetList
{
    public class GetListProfileTypeQuery:IRequest<Paginate<ProfileTypeResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public class GetListProfileTypeQueryHandler : IRequestHandler<GetListProfileTypeQuery, Paginate<ProfileTypeResponse>>
        {
            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;

            public GetListProfileTypeQueryHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<ProfileTypeResponse>> Handle(GetListProfileTypeQuery request, CancellationToken cancellationToken)
            {
                var profileTypes = await _profileTypeRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    cancellationToken:cancellationToken);

                var response = _mapper.Map<Paginate<ProfileTypeResponse>>(profileTypes);
                return response;
            }
        }
    }
}
