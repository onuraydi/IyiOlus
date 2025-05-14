using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Queries.GetList
{
    public class GetListUserProfileQuery:IRequest<Paginate<UserProfileResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, Paginate<UserProfileResponse>>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<UserProfileResponse>> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
            {
                var userProfiles = await _userProfileRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<UserProfileResponse>>(userProfiles);
                return response;
            }
        }
    }
}
